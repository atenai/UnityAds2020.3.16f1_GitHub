using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using UnityEngine.Networking;

namespace 商品券
{
    /// <summary>
    /// RSSを順に取って項目に変換する。
    /// RSS 2.0(channel/item)とRSS 1.0(RDF)で日付のタグ名が違うだけなので、
    /// 名前空間を無視してローカル名で拾っている。
    /// </summary>
    public sealed class RssFeedService : IFeedService
    {
        const string UserAgent = "UnityGiftCardSample/1.0 (personal feed reader)";
        const int RequestTimeout = 20;

        public void FetchAllAsync(IReadOnlyList<FeedDefinition> feeds,
            Action<List<GiftCardItem>, List<string>> onCompleted)
        {
            List<FeedDefinition> targets = new List<FeedDefinition>();
            foreach (FeedDefinition feed in feeds)
            {
                if (feed.Enabled && !string.IsNullOrEmpty(feed.Url)) targets.Add(feed);
            }

            FetchNext(targets, 0, new List<GiftCardItem>(), new List<string>(), onCompleted);
        }

        // 一気に投げず1件ずつ。相手側に優しいのと、どのフィードで失敗したか分かりやすいので。
        void FetchNext(List<FeedDefinition> feeds, int index, List<GiftCardItem> items, List<string> errors,
            Action<List<GiftCardItem>, List<string>> onCompleted)
        {
            if (index >= feeds.Count)
            {
                onCompleted(items, errors);
                return;
            }

            FeedDefinition feed = feeds[index];
            UnityWebRequest request = UnityWebRequest.Get(feed.Url);
            request.SetRequestHeader("User-Agent", UserAgent);
            request.timeout = RequestTimeout;

            request.SendWebRequest().completed += _ =>
            {
                bool success = request.result == UnityWebRequest.Result.Success;
                string body = success ? request.downloadHandler.text : null;
                string error = request.error;
                request.Dispose();

                if (!success)
                {
                    errors.Add(feed.Name + ": " + error);
                }
                else
                {
                    try
                    {
                        items.AddRange(Parse(body, feed.Name));
                    }
                    catch (Exception exception)
                    {
                        errors.Add(feed.Name + ": 解析できませんでした (" + exception.Message + ")");
                    }
                }

                FetchNext(feeds, index + 1, items, errors, onCompleted);
            };
        }

        static List<GiftCardItem> Parse(string xml, string feedName)
        {
            List<GiftCardItem> results = new List<GiftCardItem>();
            XDocument document = XDocument.Parse(xml);

            foreach (XElement item in document.Descendants().Where(element => element.Name.LocalName == "item"))
            {
                string link = Value(item, "link");
                if (string.IsNullOrEmpty(link)) continue;

                string rawTitle = Value(item, "title");
                if (string.IsNullOrEmpty(rawTitle)) continue;

                string title;
                string publisher;
                SplitTitle(rawTitle, out title, out publisher);

                // Google Newsは<source>に媒体名を持っている。無ければタイトル末尾から拾う。
                string sourceTag = Value(item, "source");
                if (!string.IsNullOrEmpty(sourceTag)) publisher = sourceTag;
                if (string.IsNullOrEmpty(publisher)) publisher = feedName;

                string id = Value(item, "guid");
                if (string.IsNullOrEmpty(id)) id = link;

                results.Add(new GiftCardItem(id, title, publisher, link, ParseDate(item), feedName));
            }
            return results;
        }

        static string Value(XElement parent, string localName)
        {
            foreach (XElement child in parent.Elements())
            {
                if (child.Name.LocalName == localName) return child.Value.Trim();
            }
            return null;
        }

        static DateTime ParseDate(XElement item)
        {
            // RSS 2.0 は pubDate(RFC1123)、RSS 1.0 は dc:date(ISO8601)。
            string text = Value(item, "pubDate");
            if (string.IsNullOrEmpty(text)) text = Value(item, "date");
            if (string.IsNullOrEmpty(text)) return DateTime.MinValue;

            DateTime parsed;
            bool ok = DateTime.TryParse(text, CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out parsed);
            return ok ? parsed.ToLocalTime() : DateTime.MinValue;
        }

        /// <summary>「記事名 - 媒体名」を分ける。区切りが無ければそのまま。</summary>
        static void SplitTitle(string rawTitle, out string title, out string publisher)
        {
            int separator = rawTitle.LastIndexOf(" - ", StringComparison.Ordinal);
            if (separator <= 0)
            {
                title = rawTitle;
                publisher = null;
                return;
            }

            title = rawTitle.Substring(0, separator).Trim();
            publisher = rawTitle.Substring(separator + 3).Trim();
        }
    }
}

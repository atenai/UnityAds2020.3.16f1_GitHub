using System;

namespace 商品券
{
    /// <summary>フィードから拾った1件。</summary>
    public class GiftCardItem
    {
        public string Id { get; }
        public string Title { get; }
        public string Publisher { get; }
        public string Url { get; }
        public DateTime PublishedAt { get; }
        public string FeedName { get; }

        /// <summary>前回の取得時には無かった項目。</summary>
        public bool IsNew { get; set; }

        public GiftCardItem(string id, string title, string publisher, string url, DateTime publishedAt, string feedName)
        {
            Id = id;
            Title = title;
            Publisher = publisher;
            Url = url;
            PublishedAt = publishedAt;
            FeedName = feedName;
        }
    }
}

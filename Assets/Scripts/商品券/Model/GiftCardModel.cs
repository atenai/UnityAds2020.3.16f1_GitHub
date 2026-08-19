using System;
using System.Collections.Generic;
using UnityEngine;

namespace 商品券
{
    /// <summary>フィードを集めて一覧にし、前回に無かったものを新着として知らせる。</summary>
    public class GiftCardModel
    {
        const string AutoRefreshKey = "giftcard_auto_refresh";
        const string RelevantOnlyKey = "giftcard_relevant_only";

        readonly FeedCatalog _catalog;
        readonly IFeedService _service;
        readonly ISeenRepository _seenRepository;
        readonly List<GiftCardItem> _all = new List<GiftCardItem>();
        readonly List<GiftCardItem> _visible = new List<GiftCardItem>();

        SeenStore _seen;
        bool _suppressNextNotify;

        public IReadOnlyList<GiftCardItem> Items => _visible;
        public int TotalCount => _all.Count;
        public int HiddenCount => _all.Count - _visible.Count;
        public bool IsFetching { get; private set; }
        public string ErrorMessage { get; private set; }
        public DateTime? LastFetchedAt { get; private set; }
        public int NewCount { get; private set; }
        public bool AutoRefreshEnabled { get; private set; }

        /// <summary>他県限定のものを隠すかどうか。</summary>
        public bool RelevantOnly { get; private set; }

        public event Action OnStateChanged;
        public event Action<List<GiftCardItem>> OnNewItems;

        public GiftCardModel(FeedCatalog catalog, IFeedService service, ISeenRepository seenRepository)
        {
            _catalog = catalog;
            _service = service;
            _seenRepository = seenRepository;
        }

        public void Initialize()
        {
            _seen = _seenRepository.Load();
            // 初回起動は全部が「新着」になってしまうので、そのときだけ通知を出さない。
            _suppressNextNotify = _seen.Count == 0;
            AutoRefreshEnabled = PlayerPrefs.GetInt(AutoRefreshKey, 0) == 1;
            RelevantOnly = PlayerPrefs.GetInt(RelevantOnlyKey, 1) == 1;
            OnStateChanged?.Invoke();
        }

        public void SetAutoRefresh(bool enabled)
        {
            if (AutoRefreshEnabled == enabled) return;

            AutoRefreshEnabled = enabled;
            PlayerPrefs.SetInt(AutoRefreshKey, enabled ? 1 : 0);
            PlayerPrefs.Save();
            OnStateChanged?.Invoke();
        }

        public void SetRelevantOnly(bool enabled)
        {
            if (RelevantOnly == enabled) return;

            RelevantOnly = enabled;
            PlayerPrefs.SetInt(RelevantOnlyKey, enabled ? 1 : 0);
            PlayerPrefs.Save();
            RebuildVisible();
            OnStateChanged?.Invoke();
        }

        public void Refresh()
        {
            if (IsFetching) return;

            IsFetching = true;
            ErrorMessage = null;
            OnStateChanged?.Invoke();

            _service.FetchAllAsync(_catalog.Feeds, (items, errors) =>
            {
                IsFetching = false;
                LastFetchedAt = DateTime.Now;

                List<GiftCardItem> unique = Deduplicate(items);
                unique.Sort((left, right) => right.PublishedAt.CompareTo(left.PublishedAt));

                bool suppress = _suppressNextNotify;
                _suppressNextNotify = false;

                List<GiftCardItem> fresh = new List<GiftCardItem>();
                foreach (GiftCardItem item in unique)
                {
                    bool unseen = !_seen.Contains(item.Id);
                    item.IsNew = unseen && !suppress;
                    // 隠す対象のものは新着として数えない。通知が他県の話で埋まらないように。
                    if (unseen && IsRelevant(item)) fresh.Add(item);
                    _seen.Add(item.Id);
                }
                _seenRepository.Save(_seen);

                _all.Clear();
                _all.AddRange(unique);
                RebuildVisible();

                NewCount = suppress ? 0 : fresh.Count;
                ErrorMessage = errors.Count == 0 ? null : string.Join(" / ", errors.ToArray());

                OnStateChanged?.Invoke();
                if (!suppress && fresh.Count > 0) OnNewItems?.Invoke(fresh);
            });
        }

        bool IsRelevant(GiftCardItem item)
        {
            return !RelevantOnly || item.Region != Region.OtherLocal;
        }

        void RebuildVisible()
        {
            _visible.Clear();
            foreach (GiftCardItem item in _all)
            {
                if (IsRelevant(item)) _visible.Add(item);
            }
        }

        /// <summary>同じ記事が複数のフィードに載るので、IDとURLで重複を落とす。</summary>
        static List<GiftCardItem> Deduplicate(List<GiftCardItem> items)
        {
            HashSet<string> seenKeys = new HashSet<string>();
            List<GiftCardItem> results = new List<GiftCardItem>();

            foreach (GiftCardItem item in items)
            {
                if (!seenKeys.Add(item.Id)) continue;
                if (!string.IsNullOrEmpty(item.Url) && !seenKeys.Add(item.Url)) continue;

                results.Add(item);
            }
            return results;
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace 商品券
{
    public class GiftCardPresenter
    {
        const int AutoRefreshMinutes = 15;

        readonly GiftCardModel _model;
        readonly GiftCardView _view;
        readonly INotifier _notifier;

        int _minutesSinceRefresh;

        public GiftCardPresenter(GiftCardModel model, GiftCardView view, INotifier notifier)
        {
            _model = model;
            _view = view;
            _notifier = notifier;

            _model.OnStateChanged += Render;
            _model.OnNewItems += NotifyNewItems;
            _view.OnMinuteTick += Tick;

            _view.RefreshButton.onClick.AddListener(() =>
            {
                _minutesSinceRefresh = 0;
                _model.Refresh();
            });
            _view.AutoRefreshToggle.onValueChanged.AddListener(_model.SetAutoRefresh);

            _model.Initialize();
            _model.Refresh();
        }

        void Tick()
        {
            if (!_model.AutoRefreshEnabled || _model.IsFetching) return;

            _minutesSinceRefresh++;
            if (_minutesSinceRefresh < AutoRefreshMinutes) return;

            _minutesSinceRefresh = 0;
            _model.Refresh();
        }

        void NotifyNewItems(List<GiftCardItem> fresh)
        {
            string headline = fresh.Count == 0 ? "" : fresh[0].Title;
            if (headline.Length > 40) headline = headline.Substring(0, 40) + "…";

            _notifier.Notify("新着 " + fresh.Count + "件", headline);
        }

        void Render()
        {
            _view.SetInteractable(!_model.IsFetching);
            _view.SetAutoRefresh(_model.AutoRefreshEnabled);
            _view.SetStatus(BuildStatus(), _model.NewCount > 0 ? "新着 " + _model.NewCount + "件" : "");

            IReadOnlyList<ItemRowView> rows = _view.CreateRows(_model.Items.Count);
            for (int i = 0; i < _model.Items.Count; i++)
            {
                GiftCardItem item = _model.Items[i];
                string url = item.Url;

                rows[i].Bind(item.Title, item.Publisher + " ・ " + item.FeedName, FormatDate(item.PublishedAt),
                    item.IsNew, !string.IsNullOrEmpty(url), () => Application.OpenURL(url));
            }
        }

        string BuildStatus()
        {
            if (_model.IsFetching) return "取得中…";

            string status = _model.Items.Count + "件";
            if (_model.LastFetchedAt != null) status += " ・ 最終更新 " + _model.LastFetchedAt.Value.ToString("HH:mm");
            if (_model.AutoRefreshEnabled) status += " ・ " + AutoRefreshMinutes + "分ごとに自動更新";
            if (!string.IsNullOrEmpty(_model.ErrorMessage)) status += "\n" + _model.ErrorMessage;

            return status;
        }

        static string FormatDate(DateTime value)
        {
            if (value == DateTime.MinValue) return "-";

            TimeSpan elapsed = DateTime.Now - value;
            if (elapsed.TotalHours < 1) return (int)elapsed.TotalMinutes + "分前";
            if (elapsed.TotalHours < 24) return (int)elapsed.TotalHours + "時間前";

            return value.ToString("M/d HH:mm");
        }
    }
}

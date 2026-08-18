using System;
using System.Collections.Generic;
using UnityEngine;

namespace ポイ活
{
    public class PoikatsuPresenter
    {
        static readonly TimeSpan DueSoonThreshold = TimeSpan.FromHours(1);

        readonly PoikatsuModel _model;
        readonly PoikatsuView _view;
        readonly ITaskNotifier _notifier;
        readonly ILinkOpener _opener;
        readonly HashSet<string> _notified = new HashSet<string>();

        public PoikatsuPresenter(PoikatsuModel model, PoikatsuView view, ITaskNotifier notifier, ILinkOpener opener)
        {
            _model = model;
            _view = view;
            _notifier = notifier;
            _opener = opener;

            _model.OnTasksChanged += RenderAll;
            _model.OnProgressChanged += RenderHeader;
            _view.OnTick += Tick;

            _view.BreakdownButton.onClick.AddListener(() =>
            {
                RenderBreakdown();
                _view.ShowBreakdown(true);
            });
            _view.BreakdownCloseButton.onClick.AddListener(() => _view.ShowBreakdown(false));

            _view.BulkOpenButton.onClick.AddListener(() => OpenPending("まとめて開きました"));
            _view.AutoOpenToggle.onValueChanged.AddListener(_model.SetAutoOpenEnabled);
            _view.HourMinusButton.onClick.AddListener(() => _model.ShiftAutoOpenHour(-1));
            _view.HourPlusButton.onClick.AddListener(() => _model.ShiftAutoOpenHour(1));

            _model.Initialize(DateTime.Now); // OnTasksChanged経由で初回描画が走る
        }

        /// <summary>
        /// 未完了サイトをブラウザで順に開く。
        /// ログイン自体はブラウザに残っているセッション任せで、アプリは資格情報を持たない。
        /// </summary>
        void OpenPending(string title)
        {
            List<string> urls = _model.PendingUrls();
            if (urls.Count == 0)
            {
                _notifier.Notify("開くものがありません", "未完了のタスクはありません");
                return;
            }

            List<Action> actions = new List<Action>();
            foreach (string url in urls)
            {
                string captured = url;
                actions.Add(() => _opener.Open(captured));
            }
            _view.RunStaggered(actions, 0.4f);
            _notifier.Notify(title, urls.Count + "件のサイトをブラウザで開きます");
        }

        void Tick()
        {
            DateTime now = DateTime.Now;

            if (_model.Tick(now)) // リセット時刻をまたいだらタスクが自動で復活する
            {
                _notified.Clear();
                _notifier.Notify("タスクが更新されました", _model.TotalCount + "件のポイ活タスクが受付開始です");
            }

            if (_model.ShouldAutoOpen(now)) // 設定時刻を過ぎたら1日1回だけ自動で開く
            {
                _model.MarkAutoOpened(now);
                OpenPending("自動で開きました");
            }

            NotifyDueSoon(now);
            RenderRemain(now);
        }

        void NotifyDueSoon(DateTime now)
        {
            foreach (DailyTask task in _model.DueWithin(DueSoonThreshold, now))
            {
                // 同じタスクの同じ期間で二度鳴らさない
                if (!_notified.Add(TaskProgress.MakeKey(task.Definition.Id, task.PeriodKey))) continue;

                _notifier.Notify("まもなくリセット",
                    task.Definition.Title + " の期限まで残り " + FormatSpan(task.NextResetAt - now));
            }
        }

        void RenderAll()
        {
            DateTime now = DateTime.Now;
            IReadOnlyList<TaskRowView> rows = _view.CreateRows(_model.TotalCount);

            for (int i = 0; i < _model.TotalCount; i++)
            {
                DailyTask task = _model.Tasks[i];
                TaskDefinition definition = task.Definition;
                string taskId = definition.Id;
                string url = definition.Url;

                rows[i].Bind(
                    definition.ServiceName + "  " + definition.Title,
                    "目安+" + definition.ExpectedPoints + "pt ・ 約" + definition.EstimatedMinutes + "分 ・ " + Label(definition.ResetType),
                    FormatRemain(task, now),
                    task.IsDone,
                    !string.IsNullOrEmpty(url),
                    task.EarnedPoints,
                    done => _model.SetDone(taskId, done, DateTime.Now),
                    () => _opener.Open(url),
                    points => _model.SetEarnedPoints(taskId, points, DateTime.Now));
            }

            RenderHeader();
        }

        void RenderHeader()
        {
            DateTime now = DateTime.Now;
            float progress = _model.TotalCount == 0 ? 0f : (float)_model.DoneCount / _model.TotalCount;

            _view.SetHeader(
                now.ToString("M月d日(ddd)"),
                _model.DoneCount + " / " + _model.TotalCount + " 完了 ・ 残り約" + _model.RemainingMinutes + "分",
                _model.EarnedPoints + "pt / " + _model.TotalPoints + "pt",
                progress,
                BuildCountdown(now));

            _view.SetLifetimePoint("累計 " + Format(_model.LifetimePoints) + "pt");
            _view.SetAutoOpen(_model.AutoOpenEnabled, _model.AutoOpenTimeLabel);

            if (_view.IsBreakdownOpen) RenderBreakdown();
        }

        void RenderBreakdown()
        {
            DateTime now = DateTime.Now;
            System.Text.StringBuilder labels = new System.Text.StringBuilder();
            System.Text.StringBuilder values = new System.Text.StringBuilder();

            labels.AppendLine("【期間別】");
            values.AppendLine("");
            AppendRow(labels, values, "今日", _model.PointsToday(now));
            AppendRow(labels, values, "直近7日間", _model.PointsLast7Days(now));
            AppendRow(labels, values, "今月", _model.PointsThisMonth(now));
            AppendRow(labels, values, "累計", _model.LifetimePoints);

            labels.AppendLine("");
            values.AppendLine("");
            labels.AppendLine("【サービス別・累計】");
            values.AppendLine("");

            List<KeyValuePair<string, int>> byService = _model.PointsByService();
            if (byService.Count == 0)
            {
                labels.AppendLine("まだ記録がありません");
                values.AppendLine("");
            }
            else
            {
                foreach (KeyValuePair<string, int> pair in byService)
                {
                    AppendRow(labels, values, pair.Key, pair.Value);
                }
            }

            labels.AppendLine("");
            values.AppendLine("");
            labels.Append("記録件数");
            values.Append(_model.RecordCount + "件");

            _view.SetBreakdown(labels.ToString(), values.ToString());
        }

        static void AppendRow(System.Text.StringBuilder labels, System.Text.StringBuilder values, string label, int points)
        {
            labels.AppendLine(label);
            values.AppendLine(Format(points) + "pt");
        }

        static string Format(int points)
        {
            return points.ToString("#,0");
        }

        void RenderRemain(DateTime now)
        {
            IReadOnlyList<TaskRowView> rows = _view.CreateRows(_model.TotalCount);
            for (int i = 0; i < _model.TotalCount; i++)
            {
                rows[i].SetRemainText(FormatRemain(_model.Tasks[i], now));
            }
            _view.SetCountdown(BuildCountdown(now));
        }

        string BuildCountdown(DateTime now)
        {
            DateTime? next = _model.NextResetAt;
            if (next == null) return "今日のタスクは全部完了です";

            return "次のリセットまで " + FormatSpan(next.Value - now);
        }

        static string FormatRemain(DailyTask task, DateTime now)
        {
            return task.IsDone ? "完了" : "あと " + FormatSpan(task.NextResetAt - now);
        }

        static string FormatSpan(TimeSpan span)
        {
            if (span < TimeSpan.Zero) span = TimeSpan.Zero;
            if (span.TotalDays >= 1) return (int)span.TotalDays + "日" + span.Hours + "時間";
            if (span.TotalHours >= 1) return (int)span.TotalHours + "時間" + span.Minutes + "分";
            return span.Minutes + "分" + span.Seconds + "秒";
        }

        static string Label(ResetType resetType)
        {
            switch (resetType)
            {
                case ResetType.Weekly: return "毎週";
                case ResetType.Monthly: return "毎月";
                default: return "毎日";
            }
        }
    }
}

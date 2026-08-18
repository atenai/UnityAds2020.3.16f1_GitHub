using System;
using System.Collections.Generic;

namespace ポイ活
{
    /// <summary>カタログと進捗記録から「今やるべきタスク一覧」を組み立てる。</summary>
    public class PoikatsuModel
    {
        readonly TaskCatalog _catalog;
        readonly ITaskRepository _repository;
        readonly ILedgerRepository _ledgerRepository;
        readonly ISettingsRepository _settingsRepository;
        readonly List<DailyTask> _tasks = new List<DailyTask>();

        TaskProgress _progress;
        PointLedger _ledger;
        AutoOpenSettings _settings;

        public IReadOnlyList<DailyTask> Tasks => _tasks;

        /// <summary>タスク一覧そのものが作り直された。</summary>
        public event Action OnTasksChanged;

        /// <summary>完了状態だけが変わった。</summary>
        public event Action OnProgressChanged;

        public PoikatsuModel(TaskCatalog catalog, ITaskRepository repository, ILedgerRepository ledgerRepository,
            ISettingsRepository settingsRepository)
        {
            _catalog = catalog;
            _repository = repository;
            _ledgerRepository = ledgerRepository;
            _settingsRepository = settingsRepository;
        }

        public void Initialize(DateTime now)
        {
            _progress = _repository.Load();
            _ledger = _ledgerRepository.Load();
            _settings = _settingsRepository.Load();
            Rebuild(now);
        }

        /// <summary>リセット時刻をまたいでいたらタスクを組み直す。組み直したら true。</summary>
        public bool Tick(DateTime now)
        {
            if (!HasPeriodChanged(now)) return false;

            Rebuild(now);
            return true;
        }

        public void SetDone(string taskId, bool done, DateTime now)
        {
            DailyTask task = Find(taskId);
            if (task == null || task.IsDone == done) return;

            task.IsDone = done;
            _progress.SetDone(taskId, task.PeriodKey, done);
            _repository.Save(_progress);

            // 台帳は期間をまたいでも消さない。ここが累計ポイントの元になる。
            TaskDefinition definition = task.Definition;
            if (done)
            {
                _ledger.Add(taskId, task.PeriodKey, definition.ServiceName, definition.Title, task.EarnedPoints, now);
            }
            else
            {
                _ledger.Remove(taskId, task.PeriodKey);
            }
            _ledgerRepository.Save(_ledger);

            OnProgressChanged?.Invoke();
        }

        /// <summary>実際に獲得したポイントを手で直す。完了済みなら台帳も書き換える。</summary>
        public void SetEarnedPoints(string taskId, int points, DateTime now)
        {
            DailyTask task = Find(taskId);
            if (task == null) return;

            int clamped = points < 0 ? 0 : points;
            if (task.EarnedPoints == clamped) return;

            task.EarnedPoints = clamped;

            if (task.IsDone)
            {
                TaskDefinition definition = task.Definition;
                _ledger.Remove(taskId, task.PeriodKey);
                _ledger.Add(taskId, task.PeriodKey, definition.ServiceName, definition.Title, clamped, now);
                _ledgerRepository.Save(_ledger);
            }

            OnProgressChanged?.Invoke();
        }

        /// <summary>台帳に記録した獲得ポイントの累計。</summary>
        public int LifetimePoints => _ledger.TotalPoints;

        public int PointsToday(DateTime now)
        {
            return _ledger.PointsSince(now.Date);
        }

        public int PointsLast7Days(DateTime now)
        {
            return _ledger.PointsSince(now.Date.AddDays(-6));
        }

        public int PointsThisMonth(DateTime now)
        {
            return _ledger.PointsSince(new DateTime(now.Year, now.Month, 1));
        }

        public List<KeyValuePair<string, int>> PointsByService()
        {
            return _ledger.PointsByService();
        }

        public int RecordCount => _ledger.Entries.Count;

        // ===== まとめて開く / 自動で開く =====

        public bool AutoOpenEnabled => _settings.enabled;
        public string AutoOpenTimeLabel => _settings.TimeLabel;

        /// <summary>未完了で、開き先が登録されているタスクのURL。</summary>
        public List<string> PendingUrls()
        {
            List<string> urls = new List<string>();
            foreach (DailyTask task in _tasks)
            {
                if (task.IsDone) continue;
                if (string.IsNullOrEmpty(task.Definition.Url)) continue;

                urls.Add(task.Definition.Url);
            }
            return urls;
        }

        public void SetAutoOpenEnabled(bool enabled)
        {
            if (_settings.enabled == enabled) return;

            _settings.enabled = enabled;
            _settingsRepository.Save(_settings);
            OnProgressChanged?.Invoke();
        }

        public void ShiftAutoOpenHour(int delta)
        {
            _settings.hour = (_settings.hour + delta + 24) % 24;
            _settingsRepository.Save(_settings);
            OnProgressChanged?.Invoke();
        }

        /// <summary>設定時刻を過ぎていて、今日まだ開いていなければ true。</summary>
        public bool ShouldAutoOpen(DateTime now)
        {
            if (!_settings.enabled) return false;
            if (_settings.lastOpenedDate == DateKey(now)) return false;

            return now >= now.Date.AddHours(_settings.hour).AddMinutes(_settings.minute);
        }

        public void MarkAutoOpened(DateTime now)
        {
            _settings.lastOpenedDate = DateKey(now);
            _settingsRepository.Save(_settings);
        }

        static string DateKey(DateTime value)
        {
            return value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        }

        public int TotalCount => _tasks.Count;

        public int DoneCount
        {
            get
            {
                int count = 0;
                foreach (DailyTask task in _tasks)
                {
                    if (task.IsDone) count++;
                }
                return count;
            }
        }

        public int TotalPoints
        {
            get
            {
                int points = 0;
                foreach (DailyTask task in _tasks) points += task.EarnedPoints;
                return points;
            }
        }

        public int EarnedPoints
        {
            get
            {
                int points = 0;
                foreach (DailyTask task in _tasks)
                {
                    if (task.IsDone) points += task.EarnedPoints;
                }
                return points;
            }
        }

        public int RemainingMinutes
        {
            get
            {
                int minutes = 0;
                foreach (DailyTask task in _tasks)
                {
                    if (!task.IsDone) minutes += task.Definition.EstimatedMinutes;
                }
                return minutes;
            }
        }

        /// <summary>未完了タスクのうち、いちばん早いリセット時刻。全部終わっていれば null。</summary>
        public DateTime? NextResetAt
        {
            get
            {
                DateTime? nearest = null;
                foreach (DailyTask task in _tasks)
                {
                    if (task.IsDone) continue;
                    if (nearest == null || task.NextResetAt < nearest.Value) nearest = task.NextResetAt;
                }
                return nearest;
            }
        }

        /// <summary>あと within 以内にリセットされる未完了タスク。通知の対象。</summary>
        public IEnumerable<DailyTask> DueWithin(TimeSpan within, DateTime now)
        {
            foreach (DailyTask task in _tasks)
            {
                if (task.IsDone) continue;
                if (task.NextResetAt - now <= within) yield return task;
            }
        }

        bool HasPeriodChanged(DateTime now)
        {
            int index = 0;
            foreach (TaskDefinition definition in _catalog.Tasks)
            {
                if (!definition.Enabled) continue;
                if (index >= _tasks.Count) return true;
                if (_tasks[index].PeriodKey != PeriodCalculator.CurrentKey(definition, now)) return true;
                index++;
            }
            return index != _tasks.Count;
        }

        void Rebuild(DateTime now)
        {
            _tasks.Clear();
            HashSet<string> aliveKeys = new HashSet<string>();

            foreach (TaskDefinition definition in _catalog.Tasks)
            {
                if (!definition.Enabled) continue;

                string periodKey = PeriodCalculator.CurrentKey(definition, now);

                // 既に記録済みなら台帳の実額を、まだなら目安値を初期値にする。
                int earned;
                if (!_ledger.TryGetPoints(definition.Id, periodKey, out earned)) earned = definition.ExpectedPoints;

                _tasks.Add(new DailyTask(definition, periodKey, _progress.IsDone(definition.Id, periodKey),
                    PeriodCalculator.NextResetAt(definition, now), earned));
                aliveKeys.Add(TaskProgress.MakeKey(definition.Id, periodKey));
            }

            _progress.Prune(aliveKeys);
            _repository.Save(_progress);
            OnTasksChanged?.Invoke();
        }

        DailyTask Find(string taskId)
        {
            foreach (DailyTask task in _tasks)
            {
                if (task.Definition.Id == taskId) return task;
            }
            return null;
        }
    }
}

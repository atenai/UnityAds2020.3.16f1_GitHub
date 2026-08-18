using System;
using System.Collections.Generic;
using UnityEngine;

namespace ポイ活
{
    /// <summary>
    /// 獲得ポイントの台帳。
    /// 進捗(TaskProgress)は期間が変わると消えるが、こちらは消さずに積み上げ続ける。
    /// </summary>
    [Serializable]
    public class PointLedger
    {
        [SerializeField] List<LedgerEntry> entries = new List<LedgerEntry>();

        public IReadOnlyList<LedgerEntry> Entries => entries;

        public void Add(string taskId, string periodKey, string serviceName, string title, int points, DateTime earnedAt)
        {
            if (IndexOf(taskId, periodKey) >= 0) return; // 同じ期間の二重計上を防ぐ

            entries.Add(new LedgerEntry
            {
                taskId = taskId,
                periodKey = periodKey,
                serviceName = serviceName,
                title = title,
                points = points,
                earnedAt = LedgerEntry.Stamp(earnedAt),
            });
        }

        public void Remove(string taskId, string periodKey)
        {
            int index = IndexOf(taskId, periodKey);
            if (index >= 0) entries.RemoveAt(index);
        }

        public bool TryGetPoints(string taskId, string periodKey, out int points)
        {
            int index = IndexOf(taskId, periodKey);
            points = index < 0 ? 0 : entries[index].points;
            return index >= 0;
        }

        public int TotalPoints
        {
            get
            {
                int total = 0;
                foreach (LedgerEntry entry in entries) total += entry.points;
                return total;
            }
        }

        public int PointsSince(DateTime from)
        {
            int total = 0;
            foreach (LedgerEntry entry in entries)
            {
                if (entry.EarnedAt >= from) total += entry.points;
            }
            return total;
        }

        /// <summary>サービス別の累計。多い順に並べて返す。</summary>
        public List<KeyValuePair<string, int>> PointsByService()
        {
            Dictionary<string, int> totals = new Dictionary<string, int>();
            foreach (LedgerEntry entry in entries)
            {
                string key = string.IsNullOrEmpty(entry.serviceName) ? "その他" : entry.serviceName;
                int current;
                totals.TryGetValue(key, out current);
                totals[key] = current + entry.points;
            }

            List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>(totals);
            list.Sort((left, right) => right.Value.CompareTo(left.Value));
            return list;
        }

        int IndexOf(string taskId, string periodKey)
        {
            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i].taskId == taskId && entries[i].periodKey == periodKey) return i;
            }
            return -1;
        }
    }
}

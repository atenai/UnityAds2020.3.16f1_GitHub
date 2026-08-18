using System;
using System.Collections.Generic;
using UnityEngine;

namespace ポイ活
{
    /// <summary>どのタスクをどの期間に完了したかの記録。JsonUtilityでそのまま保存する。</summary>
    [Serializable]
    public class TaskProgress
    {
        [SerializeField] List<CompletedEntry> entries = new List<CompletedEntry>();

        public static string MakeKey(string taskId, string periodKey)
        {
            return taskId + "|" + periodKey;
        }

        public bool IsDone(string taskId, string periodKey)
        {
            return IndexOf(taskId, periodKey) >= 0;
        }

        public void SetDone(string taskId, string periodKey, bool done)
        {
            int index = IndexOf(taskId, periodKey);
            if (done && index < 0)
            {
                entries.Add(new CompletedEntry { taskId = taskId, periodKey = periodKey });
            }
            else if (!done && index >= 0)
            {
                entries.RemoveAt(index);
            }
        }

        /// <summary>今の期間に存在しない記録を捨てる。ここで前日ぶんの完了が自動的に消える。</summary>
        public void Prune(HashSet<string> aliveKeys)
        {
            entries.RemoveAll(entry => !aliveKeys.Contains(MakeKey(entry.taskId, entry.periodKey)));
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

    [Serializable]
    public class CompletedEntry
    {
        public string taskId;
        public string periodKey;
    }
}

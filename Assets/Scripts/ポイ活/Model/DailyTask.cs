using System;

namespace ポイ活
{
    /// <summary>「今の期間の」タスク1件。カタログの定義＋今回の完了状態。</summary>
    public class DailyTask
    {
        public TaskDefinition Definition { get; }
        public string PeriodKey { get; }
        public DateTime NextResetAt { get; }
        public bool IsDone { get; set; }

        /// <summary>実際に獲得したポイント。初期値はカタログの目安値で、手で直せる。</summary>
        public int EarnedPoints { get; set; }

        public DailyTask(TaskDefinition definition, string periodKey, bool isDone, DateTime nextResetAt, int earnedPoints)
        {
            Definition = definition;
            PeriodKey = periodKey;
            IsDone = isDone;
            NextResetAt = nextResetAt;
            EarnedPoints = earnedPoints;
        }
    }
}

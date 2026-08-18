using System;
using System.Globalization;

namespace ポイ活
{
    /// <summary>「いつ・どのタスクで・何ポイント取ったか」の1件。</summary>
    [Serializable]
    public class LedgerEntry
    {
        public string taskId;
        public string periodKey;
        public string serviceName;
        public string title;
        public int points;
        public string earnedAt; // ISO 8601。JsonUtilityがDateTimeを扱えないので文字列で持つ。

        public DateTime EarnedAt
        {
            get
            {
                DateTime parsed;
                bool ok = DateTime.TryParse(earnedAt, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out parsed);
                return ok ? parsed : DateTime.MinValue;
            }
        }

        public static string Stamp(DateTime value)
        {
            return value.ToString("o", CultureInfo.InvariantCulture);
        }
    }
}

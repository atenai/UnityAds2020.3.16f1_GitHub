using System;
using System.Globalization;
using UnityEngine;

namespace ポイ活
{
    /// <summary>リセット時刻を考慮して「今どの期間か」「次のリセットはいつか」を計算する。</summary>
    public static class PeriodCalculator
    {
        /// <summary>同じ期間なら同じ文字列になるキー。これが変わった＝タスクが復活した。</summary>
        public static string CurrentKey(TaskDefinition definition, DateTime now)
        {
            return definition.ResetType + ":" + PeriodStart(definition, now).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public static DateTime PeriodStart(TaskDefinition definition, DateTime now)
        {
            // リセット時刻を0時とみなした時間軸にずらして考える。
            // 例) 5時リセットなら、6/28 3:00 はまだ「6/27の期間」。
            DateTime shifted = now.AddHours(-definition.ResetHour);

            switch (definition.ResetType)
            {
                case ResetType.Weekly:
                    int diff = ((int)shifted.DayOfWeek - (int)definition.ResetDayOfWeek + 7) % 7;
                    return shifted.Date.AddDays(-diff);

                case ResetType.Monthly:
                    int day = Mathf.Clamp(definition.ResetDayOfMonth, 1, 28);
                    DateTime candidate = new DateTime(shifted.Year, shifted.Month, day);
                    return shifted.Date < candidate ? candidate.AddMonths(-1) : candidate;

                default:
                    return shifted.Date;
            }
        }

        public static DateTime NextResetAt(TaskDefinition definition, DateTime now)
        {
            DateTime start = PeriodStart(definition, now);
            DateTime nextStart;
            switch (definition.ResetType)
            {
                case ResetType.Weekly:
                    nextStart = start.AddDays(7);
                    break;
                case ResetType.Monthly:
                    nextStart = start.AddMonths(1);
                    break;
                default:
                    nextStart = start.AddDays(1);
                    break;
            }
            return nextStart.AddHours(definition.ResetHour); // ずらした分を実時刻に戻す
        }
    }
}

using System;
using UnityEngine;

namespace ポイ活
{
    /// <summary>ポイ活タスク1件の定義。カタログに並べておくマスターデータ。</summary>
    [Serializable]
    public class TaskDefinition
    {
        [SerializeField] string id;
        [SerializeField] string serviceName;
        [SerializeField] string title;
        [SerializeField] ResetType resetType;
        [SerializeField, Range(0, 23)] int resetHour;
        [SerializeField] DayOfWeek resetDayOfWeek;
        [SerializeField, Range(1, 28)] int resetDayOfMonth;
        [SerializeField] int expectedPoints;
        [SerializeField] int estimatedMinutes;
        [SerializeField] string url;
        [SerializeField] bool enabled;

        public string Id => id;
        public string ServiceName => serviceName;
        public string Title => title;
        public ResetType ResetType => resetType;
        public int ResetHour => resetHour;
        public DayOfWeek ResetDayOfWeek => resetDayOfWeek;
        public int ResetDayOfMonth => resetDayOfMonth;
        public int ExpectedPoints => expectedPoints;
        public int EstimatedMinutes => estimatedMinutes;
        public string Url => url;
        public bool Enabled => enabled;

        public TaskDefinition()
        {
            resetDayOfMonth = 1;
            enabled = true;
        }

        public TaskDefinition(string id, string serviceName, string title, ResetType resetType, int resetHour,
            int expectedPoints, int estimatedMinutes, string url)
        {
            this.id = id;
            this.serviceName = serviceName;
            this.title = title;
            this.resetType = resetType;
            this.resetHour = resetHour;
            this.expectedPoints = expectedPoints;
            this.estimatedMinutes = estimatedMinutes;
            this.url = url;
            resetDayOfWeek = DayOfWeek.Monday;
            resetDayOfMonth = 1;
            enabled = true;
        }
    }
}

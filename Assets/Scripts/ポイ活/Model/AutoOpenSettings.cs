using System;

namespace ポイ活
{
    /// <summary>毎日決まった時刻に未完了サイトをまとめて開くための設定。</summary>
    [Serializable]
    public class AutoOpenSettings
    {
        public bool enabled;
        public int hour = 7;
        public int minute;
        public string lastOpenedDate = ""; // yyyy-MM-dd。1日1回に抑えるため。

        public string TimeLabel => hour.ToString("00") + ":" + minute.ToString("00");
    }
}

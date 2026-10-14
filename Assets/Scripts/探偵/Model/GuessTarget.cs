namespace 探偵
{
    /// <summary>AIに推測させるもの。プレイヤーが調べる前に選ぶ。</summary>
    public enum GuessTarget
    {
        Password,
        PhoneNumber
    }

    public static class GuessTargetNames
    {
        public static string Of(GuessTarget target)
        {
            return target == GuessTarget.PhoneNumber ? "電話番号" : "パスワード";
        }
    }
}

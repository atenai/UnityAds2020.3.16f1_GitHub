namespace 探偵
{
    /// <summary>AIに推測させるもの。プレイヤーが調べる前に選ぶ。</summary>
    public enum GuessTarget
    {
        Password,
        PhoneNumber,
        Person
    }

    public static class GuessTargetNames
    {
        public static string Of(GuessTarget target)
        {
            switch (target)
            {
                case GuessTarget.PhoneNumber:
                    return "電話番号";
                case GuessTarget.Person:
                    return "人物";
                default:
                    return "パスワード";
            }
        }
    }
}

namespace 探偵
{
    /// <summary>
    /// エージェントに渡す依頼文。調べ方や答えの書き方はエージェントの設定ファイル
    /// （StreamingAssets/TanteiAgent/tantei-investigator.md）に書いてあるので、ここでは推測するものと手掛かりだけを渡す。
    /// </summary>
    public static class ResearchPromptBuilder
    {
        public static string Build(string clue, GuessTarget target, PhoneMask mask)
        {
            string name = GuessTargetNames.Of(target);
            string prompt = "次の手掛かりを出発点に、ネット上に隠されたヒントをたどって、ゲーム内の" + name + "の候補を複数推測してください。\n" +
                            "\n" +
                            "# 推測するもの\n" +
                            name + "\n";

            if (mask != null)
            {
                prompt += "\n" +
                          "# 電話番号の形\n" +
                          mask.Pattern + "\n" +
                          "（" + PhoneMask.Hidden + " の" + mask.HiddenCount + "か所が、分からない数字です。" +
                          PhoneMask.Hidden + " の部分だけを推測し、桁数・ハイフンの位置・見えている数字は変えないでください）\n";
            }

            return prompt + "\n" +
                   "# 手掛かり\n" +
                   clue + "\n";
        }
    }
}

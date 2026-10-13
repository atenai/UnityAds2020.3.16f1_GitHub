using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace 探偵
{
    public static class Factories
    {
        public static IAiResearcher CreateResearcher(bool useFake)
        {
            if (useFake) return new FakeAiResearcher();

            // 作業フォルダはプロジェクトの外。ここでClaude Codeを起動するので、プロジェクトの設定やファイルを読ませずに済む
            string workingDirectory = Path.Combine(Application.persistentDataPath, "ai-work");

            // エージェントの設定はビルドにもそのまま入るよう StreamingAssets に置く。
            // パスワードと電話番号は「隠されたヒントをたどる」エージェント、人物は「人物を調べる」エージェントを使う
            string agentDirectory = Path.Combine(Application.streamingAssetsPath, "TanteiAgent");
            string hintAgent = Path.Combine(agentDirectory, "tantei-investigator.md");
            Dictionary<GuessTarget, string> agentPaths = new Dictionary<GuessTarget, string>
            {
                { GuessTarget.Password, hintAgent },
                { GuessTarget.PhoneNumber, hintAgent },
                { GuessTarget.Person, Path.Combine(agentDirectory, "tantei-person.md") }
            };
            return new ClaudeCodeResearcher(workingDirectory, agentPaths);
        }

        public static ILinkOpener CreateLinkOpener()
        {
            return new SystemBrowserLinkOpener();
        }

        public static IImageLoader CreateImageLoader()
        {
            return new WebImageLoader();
        }
    }
}

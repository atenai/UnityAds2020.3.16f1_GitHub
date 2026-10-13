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
            // エージェントの設定はビルドにもそのまま入るよう StreamingAssets に置く
            string agentPath = Path.Combine(Application.streamingAssetsPath, "TanteiAgent", "tantei-investigator.md");
            return new ClaudeCodeResearcher(workingDirectory, agentPath);
        }

        public static ILinkOpener CreateLinkOpener()
        {
            return new SystemBrowserLinkOpener();
        }
    }
}

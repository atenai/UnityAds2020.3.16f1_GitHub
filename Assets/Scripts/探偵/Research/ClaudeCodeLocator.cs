using System;
using System.Collections.Generic;
using System.IO;

namespace 探偵
{
    /// <summary>
    /// このPCに入っているClaude Codeの実行ファイルを探す。
    /// PATH → ネイティブ版の既定の場所 → Claudeデスクトップアプリ同梱版（いちばん新しい版）の順に見る。
    /// </summary>
    public static class ClaudeCodeLocator
    {
        static readonly string[] ExecutableNames = { "claude.exe", "claude.cmd" };

        public static string Find()
        {
            string fromPath = FindInPath();
            if (fromPath != null) return fromPath;

            string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string native = Path.Combine(home, ".local", "bin", "claude.exe");
            if (File.Exists(native)) return native;

            return FindBundledWithDesktopApp();
        }

        static string FindInPath()
        {
            string path = Environment.GetEnvironmentVariable("PATH") ?? "";
            foreach (string directory in path.Split(Path.PathSeparator))
            {
                if (string.IsNullOrWhiteSpace(directory)) continue;
                foreach (string name in ExecutableNames)
                {
                    try
                    {
                        string candidate = Path.Combine(directory.Trim().Trim('"'), name);
                        if (File.Exists(candidate)) return candidate;
                    }
                    catch (ArgumentException)
                    {
                        // PATHに使えない文字が混ざっていても、ほかの候補は見続ける
                    }
                }
            }
            return null;
        }

        // デスクトップアプリは %APPDATA%\Claude\claude-code\<版>\<ハッシュ>\claude.exe に置く。
        // アプリの更新で版のフォルダが増えるので、版番号の大きい順に探す。
        static string FindBundledWithDesktopApp()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string root = Path.Combine(appData, "Claude", "claude-code");
            if (!Directory.Exists(root)) return null;

            List<KeyValuePair<Version, string>> versions = new List<KeyValuePair<Version, string>>();
            foreach (string directory in Directory.GetDirectories(root))
            {
                if (Version.TryParse(Path.GetFileName(directory), out Version version))
                {
                    versions.Add(new KeyValuePair<Version, string>(version, directory));
                }
            }
            versions.Sort((a, b) => b.Key.CompareTo(a.Key));

            foreach (KeyValuePair<Version, string> entry in versions)
            {
                foreach (string hashDirectory in Directory.GetDirectories(entry.Value))
                {
                    string candidate = Path.Combine(hashDirectory, "claude.exe");
                    if (File.Exists(candidate)) return candidate;
                }
            }
            return null;
        }
    }
}

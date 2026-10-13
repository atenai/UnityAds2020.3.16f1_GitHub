using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace 探偵
{
    /// <summary>
    /// このPCのClaude Codeを裏で起動して、ゲーム専用エージェントに手掛かりを調べさせる。
    /// Claudeのプランの範囲で動くので追加料金はかからない。
    /// エージェントの設定ファイルは調査のたびに読み直すので、書き換えれば次の調査から反映される。
    /// 作業フォルダはプロジェクトの外の空フォルダにして、使えるツールもWeb検索とページ取得だけに絞る。
    /// エージェントの指示はシステムプロンプトとして渡す。--agent で渡すと --json-schema（答えの形の指定）が効かず、
    /// 自由な文章で返ってきてしまうため。
    /// </summary>
    public sealed class ClaudeCodeResearcher : IAiResearcher
    {
        const string PromptFileName = "agent-prompt.md";
        const string LastResponseFileName = "last-response.json"; // 読み取れなかったときに中身を確かめられるよう、直前の返事を残す

        // AIの動作に要らない通信（利用状況の統計・エラー報告・フィードバック送信・アンケート・自動更新など）を止める。
        // 手掛かりやページの内容はAIが考えるのに必要なので、Anthropicのサーバーへの送信自体は止められない。
        // WebFetchが開く前にドメイン名だけを照会する安全チェックは、危険なサイトを避けるために残している。
        static readonly string[] PrivacyEnvironmentVariables =
        {
            "CLAUDE_CODE_DISABLE_NONESSENTIAL_TRAFFIC",
            "DISABLE_TELEMETRY",
            "DISABLE_ERROR_REPORTING",
            "DISABLE_FEEDBACK_COMMAND",
            "CLAUDE_CODE_DISABLE_FEEDBACK_SURVEY"
        };

        readonly string _workingDirectory;
        readonly string _agentPath;
        readonly object _lock = new object();
        Process _running; // 中止とゲーム終了のときに止めるため、動いているプロセスを覚えておく
        bool _cancelled;

        public ClaudeCodeResearcher(string workingDirectory, string agentPath)
        {
            _workingDirectory = workingDirectory;
            _agentPath = agentPath;
        }

        public void ResearchAsync(string request, Action<ResearchResult> onCompleted)
        {
            if (!AgentDefinition.TryLoad(_agentPath, out AgentDefinition agent, out string agentError))
            {
                onCompleted(ResearchResult.Failure(agentError));
                return;
            }

            string executable = ClaudeCodeLocator.Find();
            if (executable == null)
            {
                onCompleted(ResearchResult.Failure(
                    "このPCにClaude Codeが見つかりません。Claudeデスクトップアプリか、Claude Codeをインストールしてください。"));
                return;
            }

            SynchronizationContext mainThread = SynchronizationContext.Current;
            Task.Run(() => Run(executable, agent, request)).ContinueWith(task =>
            {
                ResearchResult result = task.IsFaulted
                    ? ResearchResult.Failure("AIを呼び出せませんでした。（" + task.Exception?.GetBaseException().Message + "）")
                    : task.Result;

                if (mainThread != null) mainThread.Post(_ => onCompleted(result), null);
                else onCompleted(result);
            });
        }

        public void Cancel()
        {
            lock (_lock)
            {
                if (_running == null) return;
                _cancelled = true;
                try
                {
                    if (!_running.HasExited) _running.Kill();
                }
                catch (InvalidOperationException)
                {
                    // ちょうど終わったところなら、止めるものはもう無い
                }
            }
        }

        ResearchResult Run(string executable, AgentDefinition agent, string request)
        {
            Directory.CreateDirectory(_workingDirectory);
            string promptPath = Path.Combine(_workingDirectory, PromptFileName);
            string lastResponsePath = Path.Combine(_workingDirectory, LastResponseFileName);
            File.WriteAllText(promptPath, agent.Prompt, new UTF8Encoding(false));

            ProcessStartInfo info = new ProcessStartInfo(executable, BuildArguments(agent, promptPath))
            {
                WorkingDirectory = _workingDirectory,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8
            };
            foreach (string name in PrivacyEnvironmentVariables)
            {
                info.EnvironmentVariables[name] = "1";
            }

            using (Process process = Process.Start(info))
            {
                if (process == null) return ResearchResult.Failure("AIを起動できませんでした。");
                lock (_lock)
                {
                    _running = process;
                    _cancelled = false;
                }

                try
                {
                    // 日本語の依頼文は、コマンドライン引数だと文字化けや長さ制限が怖いので標準入力からUTF-8で渡す
                    byte[] input = new UTF8Encoding(false).GetBytes(request ?? "");
                    process.StandardInput.BaseStream.Write(input, 0, input.Length);
                    process.StandardInput.Close();

                    Task<string> stdout = process.StandardOutput.ReadToEndAsync();
                    Task<string> stderr = process.StandardError.ReadToEndAsync();
                    if (!process.WaitForExit(agent.TimeoutMinutes * 60 * 1000))
                    {
                        Cancel();
                        return ResearchResult.Failure("AIの調査が" + agent.TimeoutMinutes + "分以内に終わりませんでした。もう一度試してください。");
                    }

                    lock (_lock)
                    {
                        if (_cancelled) return ResearchResult.Failure("調査を中止しました。");
                    }
                    File.WriteAllText(lastResponsePath, stdout.Result ?? "", new UTF8Encoding(false));
                    return Parse(stdout.Result, stderr.Result, lastResponsePath);
                }
                finally
                {
                    lock (_lock)
                    {
                        _running = null;
                    }
                }
            }
        }

        static string BuildArguments(AgentDefinition agent, string promptPath)
        {
            string tools = string.Join(",", agent.Tools);
            return "-p"
                + " --output-format json"
                + " --json-schema " + Quote(ResearchReport.JsonSchema)
                + " --append-system-prompt-file " + Quote(promptPath)
                + " --model " + Quote(agent.Model)
                + " --tools " + tools
                + " --allowedTools " + tools
                // ユーザー全体の設定（~/.claude のフックやプラグインなど）は読まない。
                // 作業フォルダには設定が無いので、実質どの設定も効かない
                + " --setting-sources project"
                + " --no-session-persistence"
                + " --strict-mcp-config"
                + " --permission-prompts none";
        }

        static ResearchResult Parse(string stdout, string stderr, string lastResponsePath)
        {
            string json = ExtractJsonObject(stdout);
            if (json == null)
            {
                string detail = string.IsNullOrWhiteSpace(stderr) ? "" : "（" + stderr.Trim() + "）";
                return ResearchResult.Failure("AIの返事を読み取れませんでした。" + detail);
            }

            ClaudeCliOutput output;
            try
            {
                output = JsonUtility.FromJson<ClaudeCliOutput>(json);
            }
            catch (ArgumentException)
            {
                return ResearchResult.Failure("AIの返事を読み取れませんでした。");
            }

            if (output.is_error)
            {
                if (output.result != null && output.result.Contains("Not logged in"))
                {
                    return ResearchResult.Failure(
                        "Claude Codeにログインしていません。ターミナルで「claude auth login」を実行してログインしてください。");
                }
                return ResearchResult.Failure("AIの調査に失敗しました。（" + output.result + "）");
            }

            // JsonUtilityは無い項目も空のインスタンスで埋めるので、中身が入っているかで見る
            ResearchReport report = output.structured_output;
            if (report == null || report.IsEmpty) report = ParseReportText(output.result);
            if (report == null || report.IsEmpty)
            {
                return ResearchResult.Failure("AIの返事が想定した形になっていませんでした。返事の中身は次のファイルで確認できます：" + lastResponsePath);
            }

            return ResearchResult.Ok(report);
        }

        // 答えの形の指定が効かず文章で返ってきたときの保険。
        // ```json で囲まれていたり前後に説明文が付いていたりしても、文章中の { から始まるJSONを順に試して拾う
        static ResearchReport ParseReportText(string text)
        {
            if (string.IsNullOrEmpty(text)) return null;

            for (int start = text.IndexOf('{'); start >= 0; start = text.IndexOf('{', start + 1))
            {
                int end = FindClosingBrace(text, start);
                if (end < 0) continue;

                try
                {
                    ResearchReport report = JsonUtility.FromJson<ResearchReport>(text.Substring(start, end - start + 1));
                    if (report != null && !report.IsEmpty) return report;
                }
                catch (ArgumentException)
                {
                    // JSONとして読めない部分だったので、次の { から試す
                }
            }
            return null;
        }

        /// <summary>start の { に対応する } の位置。文字列の中の括弧は数えない。見つからなければ -1。</summary>
        static int FindClosingBrace(string text, int start)
        {
            int depth = 0;
            bool inString = false;
            bool escaped = false;
            for (int i = start; i < text.Length; i++)
            {
                char c = text[i];
                if (inString)
                {
                    if (escaped) escaped = false;
                    else if (c == '\\') escaped = true;
                    else if (c == '"') inString = false;
                    continue;
                }

                if (c == '"') inString = true;
                else if (c == '{') depth++;
                else if (c == '}' && --depth == 0) return i;
            }
            return -1;
        }

        static string ExtractJsonObject(string text)
        {
            if (string.IsNullOrEmpty(text)) return null;
            int start = text.IndexOf('{');
            int end = text.LastIndexOf('}');
            return start >= 0 && end > start ? text.Substring(start, end - start + 1) : null;
        }

        /// <summary>Windowsのコマンドライン規則で1つの引数として渡せるように囲む。</summary>
        static string Quote(string argument)
        {
            StringBuilder builder = new StringBuilder("\"");
            int backslashes = 0;
            foreach (char c in argument)
            {
                if (c == '\\')
                {
                    backslashes++;
                    continue;
                }
                if (c == '"')
                {
                    builder.Append('\\', backslashes * 2 + 1); // 引用符の直前の\は倍にして、引用符自体もエスケープ
                    builder.Append('"');
                }
                else
                {
                    builder.Append('\\', backslashes);
                    builder.Append(c);
                }
                backslashes = 0;
            }
            builder.Append('\\', backslashes * 2);
            builder.Append('"');
            return builder.ToString();
        }
    }
}

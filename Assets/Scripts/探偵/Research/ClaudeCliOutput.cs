using System;

namespace 探偵
{
    // claude -p --output-format json の出力のうち、使う部分だけ。
    // --json-schema を付けると、指定した形の答えが structured_output に入る。
    // 例(未ログイン時): {"type":"result","is_error":true,"result":"Not logged in · Please run /login", ...}

    [Serializable]
    public class ClaudeCliOutput
    {
        public bool is_error;
        public string result;
        public ResearchReport structured_output;
    }
}

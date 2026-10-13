using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace 探偵
{
    /// <summary>
    /// ゲーム専用エージェントの設定（StreamingAssets/TanteiAgent/*.md）。
    /// 先頭の --- で囲んだ部分に名前・モデル・ツール・制限時間を書き、残りの本文がエージェントへの指示になる。
    /// Claude Code には --agents にJSONで渡す。
    /// </summary>
    public sealed class AgentDefinition
    {
        // AIに使わせてよいツール。設定ファイルに他のツールを書いても使わせない（PCのファイル操作やコマンド実行をさせないため）。
        static readonly string[] AllowedTools = { "WebSearch", "WebFetch" };

        const string DefaultModel = "sonnet";
        const int DefaultTimeoutMinutes = 10;

        public string Name { get; }
        public string Description { get; }
        public string Model { get; }
        public IReadOnlyList<string> Tools { get; }
        public int TimeoutMinutes { get; }
        public string Prompt { get; }

        AgentDefinition(string name, string description, string model, IReadOnlyList<string> tools, int timeoutMinutes,
            string prompt)
        {
            Name = name;
            Description = description;
            Model = model;
            Tools = tools;
            TimeoutMinutes = timeoutMinutes;
            Prompt = prompt;
        }

        public static bool TryLoad(string path, out AgentDefinition definition, out string error)
        {
            definition = null;
            if (!File.Exists(path))
            {
                error = "エージェントの設定ファイルが見つかりません。（" + path + "）";
                return false;
            }

            string text = File.ReadAllText(path, Encoding.UTF8).TrimStart('﻿').Replace("\r\n", "\n");
            int headerEnd = text.StartsWith("---\n") ? text.IndexOf("\n---", 4, StringComparison.Ordinal) : -1;
            if (headerEnd < 0)
            {
                error = "エージェントの設定ファイルの先頭に、--- で囲んだ設定がありません。";
                return false;
            }

            Dictionary<string, string> fields = ParseHeader(text.Substring(4, headerEnd - 4));
            string prompt = text.Substring(headerEnd + 4).Trim();

            if (!fields.TryGetValue("name", out string name) || string.IsNullOrEmpty(name))
            {
                error = "エージェントの設定ファイルに name がありません。";
                return false;
            }
            if (prompt.Length == 0)
            {
                error = "エージェントの設定ファイルに、エージェントへの指示（本文）がありません。";
                return false;
            }

            fields.TryGetValue("description", out string description);
            string model = fields.TryGetValue("model", out string m) && m.Length > 0 ? m : DefaultModel;
            int timeout = fields.TryGetValue("timeoutMinutes", out string t) && int.TryParse(t, out int minutes) && minutes > 0
                ? minutes
                : DefaultTimeoutMinutes;

            definition = new AgentDefinition(name, description ?? "", model, ParseTools(fields), timeout, prompt);
            error = null;
            return true;
        }

        static Dictionary<string, string> ParseHeader(string header)
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            foreach (string line in header.Split('\n'))
            {
                int colon = line.IndexOf(':');
                if (colon <= 0) continue;
                fields[line.Substring(0, colon).Trim()] = line.Substring(colon + 1).Trim();
            }
            return fields;
        }

        static IReadOnlyList<string> ParseTools(Dictionary<string, string> fields)
        {
            List<string> tools = new List<string>();
            if (fields.TryGetValue("tools", out string value))
            {
                foreach (string tool in value.Split(','))
                {
                    string trimmed = tool.Trim();
                    if (Array.IndexOf(AllowedTools, trimmed) >= 0 && !tools.Contains(trimmed)) tools.Add(trimmed);
                }
            }
            if (tools.Count == 0) tools.AddRange(AllowedTools);
            return tools;
        }

        /// <summary>claude --agents に渡すJSON。{"名前":{"description":..,"prompt":..,"tools":[..],"model":..}}</summary>
        public string ToAgentsJson()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('{').Append(Quote(Name)).Append(":{");
            builder.Append("\"description\":").Append(Quote(Description)).Append(',');
            builder.Append("\"prompt\":").Append(Quote(Prompt)).Append(',');
            builder.Append("\"tools\":[");
            for (int i = 0; i < Tools.Count; i++)
            {
                if (i > 0) builder.Append(',');
                builder.Append(Quote(Tools[i]));
            }
            builder.Append("],\"model\":").Append(Quote(Model));
            builder.Append("}}");
            return builder.ToString();
        }

        static string Quote(string value)
        {
            StringBuilder builder = new StringBuilder("\"");
            foreach (char c in value ?? "")
            {
                switch (c)
                {
                    case '"':
                        builder.Append("\\\"");
                        break;
                    case '\\':
                        builder.Append("\\\\");
                        break;
                    case '\n':
                        builder.Append("\\n");
                        break;
                    case '\r':
                        builder.Append("\\r");
                        break;
                    case '\t':
                        builder.Append("\\t");
                        break;
                    default:
                        if (c < 0x20) builder.Append("\\u").Append(((int)c).ToString("x4"));
                        else builder.Append(c);
                        break;
                }
            }
            builder.Append('"');
            return builder.ToString();
        }
    }
}

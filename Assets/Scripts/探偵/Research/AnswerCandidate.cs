using System;
using System.Collections.Generic;
using UnityEngine;

namespace 探偵
{
    /// <summary>
    /// AIが出した答えの候補1件。confidence は high / medium / low の英語で受け取る
    /// （JSON Schemaをコマンドライン引数で渡すので、日本語を入れないようにしている）。
    /// </summary>
    [Serializable]
    public class AnswerCandidate
    {
        public const string High = "high";
        public const string Medium = "medium";
        public const string Low = "low";

        [SerializeField] string title;
        [SerializeField] string confidence;
        [SerializeField] string reasoning;
        [SerializeField] SourceLink[] sources;

        public string Title => title;
        public string Confidence => confidence;
        public string Reasoning => reasoning;
        public IReadOnlyList<SourceLink> Sources => sources ?? Array.Empty<SourceLink>();

        public string ConfidenceLabel
        {
            get
            {
                switch (confidence)
                {
                    case High:
                        return "高";
                    case Medium:
                        return "中";
                    case Low:
                        return "低";
                    default:
                        return "？";
                }
            }
        }

        public AnswerCandidate()
        {
        }

        public AnswerCandidate(string title, string confidence, string reasoning, SourceLink[] sources)
        {
            this.title = title;
            this.confidence = confidence;
            this.reasoning = reasoning;
            this.sources = sources;
        }
    }
}

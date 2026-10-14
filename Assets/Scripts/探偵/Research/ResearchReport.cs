using System;
using System.Collections.Generic;
using UnityEngine;

namespace 探偵
{
    /// <summary>AIの調査結果。どう調べたかの概要と、根拠つきの答えの候補。</summary>
    [Serializable]
    public class ResearchReport
    {
        // AIに返させるJSONの形。ここを変えたら、このクラスとエージェントの設定ファイルの説明も合わせる。
        public const string JsonSchema =
            "{\"type\":\"object\",\"properties\":{" +
            "\"summary\":{\"type\":\"string\"}," +
            "\"answers\":{\"type\":\"array\",\"items\":{\"type\":\"object\",\"properties\":{" +
            "\"title\":{\"type\":\"string\"}," +
            "\"confidence\":{\"type\":\"string\",\"enum\":[\"high\",\"medium\",\"low\"]}," +
            "\"reasoning\":{\"type\":\"string\"}," +
            "\"sources\":{\"type\":\"array\",\"items\":{\"type\":\"object\",\"properties\":{" +
            "\"title\":{\"type\":\"string\"},\"url\":{\"type\":\"string\"}},\"required\":[\"title\",\"url\"]}}}," +
            "\"required\":[\"title\",\"confidence\",\"reasoning\",\"sources\"]}}}," +
            "\"required\":[\"summary\",\"answers\"]}";

        [SerializeField] string summary;
        [SerializeField] AnswerCandidate[] answers;

        public string Summary => summary;
        public IReadOnlyList<AnswerCandidate> Answers => answers ?? Array.Empty<AnswerCandidate>();

        public bool IsEmpty => Answers.Count == 0 && string.IsNullOrEmpty(summary);

        public ResearchReport()
        {
        }

        public ResearchReport(string summary, AnswerCandidate[] answers)
        {
            this.summary = summary;
            this.answers = answers;
        }
    }
}

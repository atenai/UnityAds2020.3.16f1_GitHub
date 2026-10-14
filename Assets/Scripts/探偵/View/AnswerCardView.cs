using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace 探偵
{
    /// <summary>答えの候補1件のカード。見出し・確からしさ・理由・根拠のページを並べる。</summary>
    public class AnswerCardView : MonoBehaviour
    {
        [SerializeField] Text headerText;
        [SerializeField] Image confidenceBadge;
        [SerializeField] Text confidenceText;
        [SerializeField] Text reasoningText;
        [SerializeField] RectTransform sourceParent;
        [SerializeField] SourceRowView sourceTemplate;

        static readonly Color HighColor = new Color(0.22f, 0.5f, 0.32f);
        static readonly Color MediumColor = new Color(0.78f, 0.55f, 0.15f);
        static readonly Color LowColor = new Color(0.5f, 0.52f, 0.56f);

        readonly List<SourceRowView> _rows = new List<SourceRowView>();

        void Awake()
        {
            sourceTemplate.gameObject.SetActive(false);
        }

        public void Bind(int number, string title, string confidence, string confidenceLabel, string reasoning,
            IReadOnlyList<SourceLink> sources, Func<string, bool> canOpen, Action<string> onOpen)
        {
            headerText.text = "答え候補 " + number + "　" + title;
            confidenceText.text = "確からしさ：" + confidenceLabel;
            confidenceBadge.color = ColorOf(confidence);
            reasoningText.text = reasoning;

            while (_rows.Count < sources.Count)
            {
                _rows.Add(Instantiate(sourceTemplate, sourceParent));
            }
            for (int i = 0; i < _rows.Count; i++)
            {
                bool isUsed = i < sources.Count;
                _rows[i].gameObject.SetActive(isUsed);
                if (!isUsed) continue;

                string url = sources[i].Url;
                _rows[i].Bind(sources[i].Title, url, canOpen(url), () => onOpen(url));
            }
        }

        static Color ColorOf(string confidence)
        {
            switch (confidence)
            {
                case AnswerCandidate.High:
                    return HighColor;
                case AnswerCandidate.Medium:
                    return MediumColor;
                default:
                    return LowColor;
            }
        }
    }
}

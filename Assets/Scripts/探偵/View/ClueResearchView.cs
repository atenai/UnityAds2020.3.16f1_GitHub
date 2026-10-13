using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace 探偵
{
    /// <summary>手掛かりの入力欄、調査中の表示、調査の概要と答え候補のカードを出す画面。</summary>
    public class ClueResearchView : MonoBehaviour
    {
        [SerializeField] Button passwordTargetButton;
        [SerializeField] Button phoneTargetButton;
        [SerializeField] InputField clueInput;
        [SerializeField] Button searchButton;
        [SerializeField] Button cancelButton;
        [SerializeField] Text statusText;
        [SerializeField] ScrollRect resultScroll;
        [SerializeField] GameObject summaryPanel;
        [SerializeField] TypewriterText summaryText;
        [SerializeField] RectTransform cardParent;
        [SerializeField] AnswerCardView cardTemplate;

        static readonly Color SelectedTargetColor = new Color(0.85f, 0.68f, 0.3f);
        static readonly Color UnselectedTargetColor = new Color(0.16f, 0.21f, 0.33f);
        static readonly Color SelectedTargetTextColor = new Color(0.13f, 0.14f, 0.19f);
        static readonly Color UnselectedTargetTextColor = new Color(0.85f, 0.86f, 0.9f);

        readonly List<AnswerCardView> _cards = new List<AnswerCardView>();

        public Button PasswordTargetButton => passwordTargetButton;
        public Button PhoneTargetButton => phoneTargetButton;
        public Button SearchButton => searchButton;
        public Button CancelButton => cancelButton;
        public string ClueText => clueInput.text;

        /// <summary>1秒ごとに発火する。Presenterが経過時間の表示に使う。</summary>
        public event Action OnTick;

        void Awake()
        {
            cardTemplate.gameObject.SetActive(false);
            summaryPanel.SetActive(false);
            cancelButton.gameObject.SetActive(false);
            ApplyJapaneseFont();
        }

        void Start()
        {
            StartCoroutine(TickLoop());
            clueInput.ActivateInputField(); // 起動したらすぐ打ち込めるように
        }

        public void SetStatus(string message)
        {
            statusText.text = message;
        }

        /// <summary>調査中は入力と切り替えを止め、検索ボタンと同じ場所に中止ボタンを出す。</summary>
        public void SetBusy(bool isBusy)
        {
            clueInput.interactable = !isBusy;
            passwordTargetButton.interactable = !isBusy;
            phoneTargetButton.interactable = !isBusy;
            searchButton.gameObject.SetActive(!isBusy);
            cancelButton.gameObject.SetActive(isBusy);
        }

        public void SetPlaceholder(string text)
        {
            if (clueInput.placeholder is Text placeholder) placeholder.text = text;
        }

        /// <summary>選ばれているほうの切り替えボタンを目立たせる。</summary>
        public void SetTarget(GuessTarget target)
        {
            PaintTarget(passwordTargetButton, target == GuessTarget.Password);
            PaintTarget(phoneTargetButton, target == GuessTarget.PhoneNumber);
        }

        static void PaintTarget(Button button, bool isSelected)
        {
            button.image.color = isSelected ? SelectedTargetColor : UnselectedTargetColor;
            Text label = button.GetComponentInChildren<Text>(true);
            if (label != null) label.color = isSelected ? SelectedTargetTextColor : UnselectedTargetTextColor;
        }

        public void ClearResults()
        {
            summaryPanel.SetActive(false);
            CreateCards(0);
        }

        public void SetSummary(string summary)
        {
            summaryPanel.SetActive(true);
            summaryText.Play(summary);
            resultScroll.verticalNormalizedPosition = 1f;
        }

        /// <summary>必要な枚数だけ用意して返す。余ったカードは隠す。</summary>
        public IReadOnlyList<AnswerCardView> CreateCards(int count)
        {
            while (_cards.Count < count)
            {
                AnswerCardView card = Instantiate(cardTemplate, cardParent);
                _cards.Add(card);
            }
            for (int i = 0; i < _cards.Count; i++)
            {
                _cards[i].gameObject.SetActive(i < count);
            }
            return _cards;
        }

        IEnumerator TickLoop()
        {
            WaitForSeconds wait = new WaitForSeconds(1f);
            while (true)
            {
                yield return wait;
                OnTick?.Invoke();
            }
        }

        static readonly string[] JapaneseFontNames =
            { "Yu Gothic UI", "Meiryo", "MS Gothic", "Hiragino Sans", "Noto Sans CJK JP", "Noto Sans JP" };

        // 組み込みフォントだと日本語が豆腐になることがあるので、OSのフォントに差し替える。
        // 端末に無い名前だけを渡すと何も描けないフォントになりうるので、入っているものだけ使う。
        void ApplyJapaneseFont()
        {
            List<string> installed = new List<string>(Font.GetOSInstalledFontNames());
            List<string> candidates = JapaneseFontNames.Where(installed.Contains).ToList();
            if (candidates.Count == 0) return;

            Font font = Font.CreateDynamicFontFromOSFont(candidates.ToArray(), 32);
            if (font == null) return;

            foreach (Text text in GetComponentsInChildren<Text>(true))
            {
                text.font = font;
            }
        }
    }
}

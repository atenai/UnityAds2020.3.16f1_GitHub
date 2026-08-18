using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ポイ活
{
    public class PoikatsuView : MonoBehaviour
    {
        [SerializeField] Text dateText;
        [SerializeField] Text summaryText;
        [SerializeField] Text pointText;
        [SerializeField] Image progressFill;
        [SerializeField] Text countdownText;
        [SerializeField] RectTransform rowParent;
        [SerializeField] TaskRowView rowTemplate;
        [SerializeField] GameObject banner;
        [SerializeField] Text bannerText;
        [SerializeField] Text lifetimePointText;
        [SerializeField] Button breakdownButton;
        [SerializeField] GameObject breakdownPanel;
        [SerializeField] Button breakdownCloseButton;
        [SerializeField] Text breakdownLabelText;
        [SerializeField] Text breakdownValueText;
        [SerializeField] Button bulkOpenButton;
        [SerializeField] Toggle autoOpenToggle;
        [SerializeField] Text autoOpenTimeText;
        [SerializeField] Button hourMinusButton;
        [SerializeField] Button hourPlusButton;

        readonly List<TaskRowView> _rows = new List<TaskRowView>();

        public Button BreakdownButton => breakdownButton;
        public Button BreakdownCloseButton => breakdownCloseButton;
        public bool IsBreakdownOpen => breakdownPanel.activeSelf;
        public Button BulkOpenButton => bulkOpenButton;
        public Toggle AutoOpenToggle => autoOpenToggle;
        public Button HourMinusButton => hourMinusButton;
        public Button HourPlusButton => hourPlusButton;

        /// <summary>1秒ごとに発火する。Presenterがリセット判定と残り時間の更新に使う。</summary>
        public event Action OnTick;

        void Awake()
        {
            rowTemplate.gameObject.SetActive(false);
            banner.SetActive(false);
            breakdownPanel.SetActive(false);
            ApplyJapaneseFont();
        }

        void Start()
        {
            StartCoroutine(TickLoop());
        }

        /// <summary>必要な行数だけ用意して返す。余った行は隠す。</summary>
        public IReadOnlyList<TaskRowView> CreateRows(int count)
        {
            while (_rows.Count < count)
            {
                TaskRowView row = Instantiate(rowTemplate, rowParent);
                _rows.Add(row);
            }
            for (int i = 0; i < _rows.Count; i++)
            {
                _rows[i].gameObject.SetActive(i < count);
            }
            return _rows;
        }

        public void SetHeader(string date, string summary, string point, float progress01, string countdown)
        {
            dateText.text = date;
            summaryText.text = summary;
            pointText.text = point;
            progressFill.fillAmount = Mathf.Clamp01(progress01);
            countdownText.text = countdown;
        }

        public void SetCountdown(string countdown)
        {
            countdownText.text = countdown;
        }

        public void SetLifetimePoint(string text)
        {
            lifetimePointText.text = text;
        }

        /// <summary>左に項目名、右に数値。列を分けておくと桁が揃う。</summary>
        public void SetBreakdown(string labels, string values)
        {
            breakdownLabelText.text = labels;
            breakdownValueText.text = values;
        }

        public void ShowBreakdown(bool show)
        {
            breakdownPanel.SetActive(show);
        }

        public void SetAutoOpen(bool enabled, string timeLabel)
        {
            autoOpenToggle.isOn = enabled; // 同じ値ならUnity側がイベントを飛ばさない
            autoOpenTimeText.text = timeLabel;
        }

        /// <summary>一気に開くとブラウザが取りこぼすので、少し間隔を空けて順に実行する。</summary>
        public void RunStaggered(IReadOnlyList<Action> actions, float interval)
        {
            StartCoroutine(StaggerRoutine(actions, interval));
        }

        IEnumerator StaggerRoutine(IReadOnlyList<Action> actions, float interval)
        {
            WaitForSeconds wait = new WaitForSeconds(interval);
            for (int i = 0; i < actions.Count; i++)
            {
                actions[i]?.Invoke();
                yield return wait;
            }
        }

        public void ShowBanner(string title, string message)
        {
            banner.SetActive(true);
            bannerText.text = title + "\n" + message;
            CancelInvoke(nameof(HideBanner));
            Invoke(nameof(HideBanner), 5f);
        }

        void HideBanner()
        {
            banner.SetActive(false);
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

        // 組み込みArialだと日本語が豆腐になるので、OSのフォントに差し替える。
        void ApplyJapaneseFont()
        {
            Font font = Font.CreateDynamicFontFromOSFont(
                new[] { "Yu Gothic UI", "Meiryo", "MS Gothic", "Hiragino Sans", "Noto Sans CJK JP" }, 32);
            if (font == null) return;

            foreach (Text text in GetComponentsInChildren<Text>(true))
            {
                text.font = font;
            }
        }
    }
}

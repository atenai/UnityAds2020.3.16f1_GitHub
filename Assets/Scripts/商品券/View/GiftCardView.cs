using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace 商品券
{
    public class GiftCardView : MonoBehaviour
    {
        [SerializeField] Text statusText;
        [SerializeField] Text newCountText;
        [SerializeField] Button refreshButton;
        [SerializeField] Toggle autoRefreshToggle;
        [SerializeField] RectTransform rowParent;
        [SerializeField] ItemRowView rowTemplate;
        [SerializeField] GameObject banner;
        [SerializeField] Text bannerText;

        readonly List<ItemRowView> _rows = new List<ItemRowView>();

        public Button RefreshButton => refreshButton;
        public Toggle AutoRefreshToggle => autoRefreshToggle;

        /// <summary>1分ごとに発火する。Presenterが自動更新の判定に使う。</summary>
        public event Action OnMinuteTick;

        void Awake()
        {
            rowTemplate.gameObject.SetActive(false);
            banner.SetActive(false);
            ApplyJapaneseFont();
        }

        void Start()
        {
            StartCoroutine(TickLoop());
        }

        public IReadOnlyList<ItemRowView> CreateRows(int count)
        {
            while (_rows.Count < count)
            {
                _rows.Add(Instantiate(rowTemplate, rowParent));
            }
            for (int i = 0; i < _rows.Count; i++)
            {
                _rows[i].gameObject.SetActive(i < count);
            }
            return _rows;
        }

        public void SetStatus(string status, string newCount)
        {
            statusText.text = status;
            newCountText.text = newCount;
        }

        public void SetAutoRefresh(bool enabled)
        {
            autoRefreshToggle.isOn = enabled;
        }

        public void SetInteractable(bool interactable)
        {
            refreshButton.interactable = interactable;
        }

        public void ShowBanner(string title, string message)
        {
            banner.SetActive(true);
            bannerText.text = title + "\n" + message;
            CancelInvoke(nameof(HideBanner));
            Invoke(nameof(HideBanner), 6f);
        }

        void HideBanner()
        {
            banner.SetActive(false);
        }

        IEnumerator TickLoop()
        {
            WaitForSeconds wait = new WaitForSeconds(60f);
            while (true)
            {
                yield return wait;
                OnMinuteTick?.Invoke();
            }
        }

        // 組み込みフォントだと日本語が豆腐になるので、OSのフォントに差し替える。
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

using System;
using UnityEngine;
using UnityEngine.UI;

namespace 人物検索
{
    /// <summary>表の1行。</summary>
    public class PersonRowView : MonoBehaviour
    {
        [SerializeField] Image background;
        [SerializeField] Image thumbnail;
        [SerializeField] Text noImageText;
        [SerializeField] Text nameText;
        [SerializeField] Text descriptionText;
        [SerializeField] Text summaryText;
        [SerializeField] Button openButton;

        static readonly Color EvenColor = new Color(1f, 1f, 1f);
        static readonly Color OddColor = new Color(0.96f, 0.97f, 0.99f);

        /// <summary>今この行が表示すべき画像のURL。遅れて届いた画像を捨てる判定に使う。</summary>
        public string ImageUrl { get; private set; }

        public void Bind(string name, string description, string summary, string imageUrl, bool isEven, bool canOpen,
            Action onOpen)
        {
            nameText.text = name;
            descriptionText.text = description;
            summaryText.text = summary;
            background.color = isEven ? EvenColor : OddColor;

            ImageUrl = imageUrl;
            thumbnail.sprite = null;
            thumbnail.enabled = false;
            noImageText.enabled = true;
            noImageText.text = string.IsNullOrEmpty(imageUrl) ? "画像なし" : "…";

            openButton.onClick.RemoveAllListeners();
            openButton.onClick.AddListener(() => onOpen?.Invoke());
            openButton.gameObject.SetActive(canOpen);
        }

        /// <summary>行が使い回されている間に届いた古い画像は捨てる。</summary>
        public void ApplyImage(string requestedUrl, Sprite sprite)
        {
            if (requestedUrl != ImageUrl) return;

            if (sprite == null)
            {
                thumbnail.enabled = false;
                noImageText.enabled = true;
                noImageText.text = "画像なし";
                return;
            }

            thumbnail.sprite = sprite;
            thumbnail.enabled = true;
            noImageText.enabled = false;
        }
    }
}

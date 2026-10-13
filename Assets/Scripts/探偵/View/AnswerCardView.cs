using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace 探偵
{
    /// <summary>
    /// 答えの候補1件のカード。見出し・確からしさ・理由・根拠のページを並べる。
    /// 人物のときは、ひとこと説明・画像・詳細情報も出す。
    /// </summary>
    public class AnswerCardView : MonoBehaviour
    {
        [SerializeField] Text headerText;
        [SerializeField] Text subtitleText;
        [SerializeField] Image confidenceBadge;
        [SerializeField] Text confidenceText;
        [SerializeField] Text reasoningText;
        [SerializeField] Text detailsText;
        [SerializeField] GameObject imageFrame;
        [SerializeField] Button imageButton;
        [SerializeField] RawImage imageView;
        [SerializeField] AspectRatioFitter imageAspect;
        [SerializeField] Text imageStatusText;
        [SerializeField] RectTransform sourceParent;
        [SerializeField] SourceRowView sourceTemplate;

        static readonly Color HighColor = new Color(0.22f, 0.5f, 0.32f);
        static readonly Color MediumColor = new Color(0.78f, 0.55f, 0.15f);
        static readonly Color LowColor = new Color(0.5f, 0.52f, 0.56f);

        readonly List<SourceRowView> _rows = new List<SourceRowView>();
        string _imageUrl;
        Texture2D _texture;

        void Awake()
        {
            sourceTemplate.gameObject.SetActive(false);
        }

        void OnDestroy()
        {
            ReleaseTexture();
        }

        public void Bind(int number, string title, string subtitle, string confidence, string confidenceLabel,
            string reasoning, IReadOnlyList<DetailItem> details, IReadOnlyList<SourceLink> sources,
            Func<string, bool> canOpen, Action<string> onOpen)
        {
            headerText.text = "答え候補 " + number + "　" + title;
            subtitleText.text = subtitle;
            subtitleText.gameObject.SetActive(!string.IsNullOrEmpty(subtitle));
            confidenceText.text = "確からしさ：" + confidenceLabel;
            confidenceBadge.color = ColorOf(confidence);
            reasoningText.text = reasoning;
            detailsText.text = FormatDetails(details);
            detailsText.gameObject.SetActive(details.Count > 0);
            HideImage();

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

        /// <summary>画像の枠を出して「読み込み中」にする。枠をクリックすると画像をブラウザで開ける。</summary>
        public void ShowImageLoading(string url, Action onOpen)
        {
            ReleaseTexture();
            _imageUrl = url;
            imageFrame.SetActive(true);
            imageView.enabled = false;
            imageStatusText.gameObject.SetActive(true);
            imageStatusText.text = "画像を読み込み中…";
            imageButton.onClick.RemoveAllListeners();
            imageButton.onClick.AddListener(() => onOpen?.Invoke());
        }

        /// <summary>読み込んだ画像を出す。読めなかったとき（texture が null）は、ブラウザで開く案内にする。</summary>
        public void SetImage(string url, Texture2D texture)
        {
            if (url != _imageUrl)
            {
                // 読み込みの途中でカードの中身が入れ替わった。古い画像は使わずに捨てる
                if (texture != null) Destroy(texture);
                return;
            }
            if (texture == null)
            {
                imageStatusText.text = "画像を表示できませんでした\n（クリックでブラウザで開く）";
                return;
            }

            _texture = texture;
            imageView.texture = texture;
            imageView.enabled = true;
            imageAspect.aspectRatio = (float)texture.width / texture.height;
            imageStatusText.gameObject.SetActive(false);
        }

        public void HideImage()
        {
            ReleaseTexture();
            _imageUrl = null;
            imageFrame.SetActive(false);
        }

        void ReleaseTexture()
        {
            if (_texture == null) return;
            imageView.texture = null;
            Destroy(_texture);
            _texture = null;
        }

        static string FormatDetails(IReadOnlyList<DetailItem> details)
        {
            StringBuilder builder = new StringBuilder();
            foreach (DetailItem item in details)
            {
                if (builder.Length > 0) builder.Append('\n');
                builder.Append(item.Label).Append("：").Append(item.Value);
            }
            return builder.ToString();
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

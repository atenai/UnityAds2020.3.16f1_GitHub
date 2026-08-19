using System;
using UnityEngine;
using UnityEngine.UI;

namespace 商品券
{
    /// <summary>一覧の1行。</summary>
    public class ItemRowView : MonoBehaviour
    {
        [SerializeField] Image background;
        [SerializeField] GameObject newBadge;
        [SerializeField] Image regionTag;
        [SerializeField] Text regionTagText;
        [SerializeField] Text titleText;
        [SerializeField] Text publisherText;
        [SerializeField] Text dateText;
        [SerializeField] Button openButton;

        static readonly Color NormalColor = new Color(1f, 1f, 1f);
        static readonly Color NewColor = new Color(1f, 0.98f, 0.90f);
        static readonly Color NationwideColor = new Color(0.13f, 0.55f, 0.35f);
        static readonly Color TokyoColor = new Color(0.20f, 0.47f, 0.86f);
        static readonly Color OtherColor = new Color(0.60f, 0.60f, 0.62f);

        public void Bind(string title, string publisher, string date, Region region, bool isNew, bool canOpen,
            Action onOpen)
        {
            titleText.text = title;
            publisherText.text = publisher;
            dateText.text = date;
            newBadge.SetActive(isNew);
            background.color = isNew ? NewColor : NormalColor;

            regionTagText.text = RegionClassifier.Label(region);
            regionTag.color = TagColor(region);

            openButton.onClick.RemoveAllListeners();
            openButton.onClick.AddListener(() => onOpen?.Invoke());
            openButton.gameObject.SetActive(canOpen);
        }

        static Color TagColor(Region region)
        {
            switch (region)
            {
                case Region.Nationwide: return NationwideColor;
                case Region.Tokyo: return TokyoColor;
                default: return OtherColor;
            }
        }
    }
}

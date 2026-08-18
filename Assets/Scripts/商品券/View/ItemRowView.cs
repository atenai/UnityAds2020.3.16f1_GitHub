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
        [SerializeField] Text titleText;
        [SerializeField] Text publisherText;
        [SerializeField] Text dateText;
        [SerializeField] Button openButton;

        static readonly Color NormalColor = new Color(1f, 1f, 1f);
        static readonly Color NewColor = new Color(1f, 0.98f, 0.90f);

        public void Bind(string title, string publisher, string date, bool isNew, bool canOpen, Action onOpen)
        {
            titleText.text = title;
            publisherText.text = publisher;
            dateText.text = date;
            newBadge.SetActive(isNew);
            background.color = isNew ? NewColor : NormalColor;

            openButton.onClick.RemoveAllListeners();
            openButton.onClick.AddListener(() => onOpen?.Invoke());
            openButton.gameObject.SetActive(canOpen);
        }
    }
}

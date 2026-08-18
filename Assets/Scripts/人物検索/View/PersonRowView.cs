using System;
using UnityEngine;
using UnityEngine.UI;

namespace 人物検索
{
    /// <summary>表の1行。</summary>
    public class PersonRowView : MonoBehaviour
    {
        [SerializeField] Image background;
        [SerializeField] Text nameText;
        [SerializeField] Text descriptionText;
        [SerializeField] Text summaryText;
        [SerializeField] Button openButton;

        static readonly Color EvenColor = new Color(1f, 1f, 1f);
        static readonly Color OddColor = new Color(0.96f, 0.97f, 0.99f);

        public void Bind(string name, string description, string summary, bool isEven, bool canOpen, Action onOpen)
        {
            nameText.text = name;
            descriptionText.text = description;
            summaryText.text = summary;
            background.color = isEven ? EvenColor : OddColor;

            openButton.onClick.RemoveAllListeners();
            openButton.onClick.AddListener(() => onOpen?.Invoke());
            openButton.gameObject.SetActive(canOpen);
        }
    }
}

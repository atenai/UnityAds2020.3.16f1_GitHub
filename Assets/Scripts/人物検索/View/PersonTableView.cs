using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace 人物検索
{
    public class PersonTableView : MonoBehaviour
    {
        [SerializeField] InputField searchField;
        [SerializeField] Button searchButton;
        [SerializeField] Button sourcePrevButton;
        [SerializeField] Button sourceNextButton;
        [SerializeField] Text sourceLabel;
        [SerializeField] Button nameSortButton;
        [SerializeField] Button descriptionSortButton;
        [SerializeField] Text nameHeaderText;
        [SerializeField] Text descriptionHeaderText;
        [SerializeField] Text statusText;
        [SerializeField] RectTransform rowParent;
        [SerializeField] PersonRowView rowTemplate;

        readonly List<PersonRowView> _rows = new List<PersonRowView>();

        public InputField SearchField => searchField;
        public Button SearchButton => searchButton;
        public Button SourcePrevButton => sourcePrevButton;
        public Button SourceNextButton => sourceNextButton;
        public Button NameSortButton => nameSortButton;
        public Button DescriptionSortButton => descriptionSortButton;

        public string Keyword => searchField.text;

        void Awake()
        {
            rowTemplate.gameObject.SetActive(false);
            ApplyJapaneseFont();
        }

        public IReadOnlyList<PersonRowView> CreateRows(int count)
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

        public void SetStatus(string message)
        {
            statusText.text = message;
        }

        public void SetSourceLabel(string label)
        {
            sourceLabel.text = label;
        }

        public void SetHeaderLabels(string name, string description)
        {
            nameHeaderText.text = name;
            descriptionHeaderText.text = description;
        }

        public void SetInteractable(bool interactable)
        {
            searchButton.interactable = interactable;
            searchField.interactable = interactable;
            sourcePrevButton.interactable = interactable;
            sourceNextButton.interactable = interactable;
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

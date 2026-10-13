using System;
using UnityEngine;
using UnityEngine.UI;

namespace 探偵
{
    /// <summary>答えカードの中の、根拠のページ1件。</summary>
    public class SourceRowView : MonoBehaviour
    {
        [SerializeField] Text titleText;
        [SerializeField] Text urlText;
        [SerializeField] Button openButton;

        public void Bind(string title, string url, bool canOpen, Action onOpen)
        {
            titleText.text = title;
            urlText.text = url;

            openButton.onClick.RemoveAllListeners();
            openButton.onClick.AddListener(() => onOpen?.Invoke());
            openButton.interactable = canOpen;
        }
    }
}

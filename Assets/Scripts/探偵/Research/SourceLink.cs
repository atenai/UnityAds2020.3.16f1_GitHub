using System;
using UnityEngine;

namespace 探偵
{
    /// <summary>答えの根拠にしたWebページ1件。</summary>
    [Serializable]
    public class SourceLink
    {
        [SerializeField] string title;
        [SerializeField] string url;

        public string Title => title;
        public string Url => url;

        public SourceLink()
        {
        }

        public SourceLink(string title, string url)
        {
            this.title = title;
            this.url = url;
        }
    }
}

using System;
using UnityEngine;

namespace 商品券
{
    /// <summary>購読するフィード1件の定義。</summary>
    [Serializable]
    public class FeedDefinition
    {
        [SerializeField] string name;
        [SerializeField] string url;
        [SerializeField] bool enabled;

        public string Name => name;
        public string Url => url;
        public bool Enabled => enabled;

        public FeedDefinition()
        {
            enabled = true;
        }

        public FeedDefinition(string name, string url)
        {
            this.name = name;
            this.url = url;
            enabled = true;
        }
    }
}

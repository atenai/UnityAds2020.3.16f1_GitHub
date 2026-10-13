using System;
using UnityEngine;

namespace 探偵
{
    /// <summary>人物の詳細情報の1項目（例：声優／花江夏樹）。</summary>
    [Serializable]
    public class DetailItem
    {
        [SerializeField] string label;
        [SerializeField] string value;

        public string Label => label;
        public string Value => value;

        public DetailItem()
        {
        }

        public DetailItem(string label, string value)
        {
            this.label = label;
            this.value = value;
        }
    }
}

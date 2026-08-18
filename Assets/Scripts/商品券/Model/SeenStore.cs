using System;
using System.Collections.Generic;
using UnityEngine;

namespace 商品券
{
    /// <summary>通知済みの項目ID。これがあるので同じ項目で二度通知しない。</summary>
    [Serializable]
    public class SeenStore
    {
        const int MaxKeep = 500;

        [SerializeField] List<string> ids = new List<string>();

        public bool Contains(string id)
        {
            return ids.Contains(id);
        }

        public void Add(string id)
        {
            if (string.IsNullOrEmpty(id) || ids.Contains(id)) return;

            ids.Add(id);
            // 古いものから捨てる。放っておくと際限なく増えるため。
            if (ids.Count > MaxKeep) ids.RemoveRange(0, ids.Count - MaxKeep);
        }

        public int Count => ids.Count;
    }
}

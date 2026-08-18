using System;
using UnityEngine;

namespace 人物検索
{
    /// <summary>画像を取りに行かない差し替え用。通信を減らして確認したいとき。</summary>
    public sealed class NullImageLoader : IImageLoader
    {
        public void Load(string url, Action<Sprite> onLoaded)
        {
            onLoaded(null);
        }
    }
}

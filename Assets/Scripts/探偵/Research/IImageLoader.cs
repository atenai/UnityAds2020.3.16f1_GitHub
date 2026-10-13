using System;
using UnityEngine;

namespace 探偵
{
    public interface IImageLoader
    {
        /// <summary>画像を読み込んでメインスレッドで返す。読めなかったときは null を返す。</summary>
        void Load(string url, Action<Texture2D> onLoaded);
    }
}

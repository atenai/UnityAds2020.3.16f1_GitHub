using System;
using UnityEngine;

namespace 人物検索
{
    public interface IImageLoader
    {
        void Load(string url, Action<Sprite> onLoaded);
    }
}

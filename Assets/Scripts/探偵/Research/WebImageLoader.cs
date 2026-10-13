using System;
using UnityEngine;
using UnityEngine.Networking;

namespace 探偵
{
    /// <summary>
    /// 人物の画像をネットから読み込む。ブラウザと同じようにその場で表示するだけで、保存はしない。
    /// Unityが読めるのはJPGとPNGだけなので、WebPなどは「読めなかった」として null を返す。
    /// </summary>
    public sealed class WebImageLoader : IImageLoader
    {
        const string UserAgent = "TanteiGame/1.0 (Unity learning project)";
        const int TimeoutSeconds = 15;
        const int BrokenTextureSize = 8; // 画像として読めないデータは、Unityが8x8の「?」画像にしてしまう

        public void Load(string url, Action<Texture2D> onLoaded)
        {
            if (!SystemBrowserLinkOpener.IsWebUrl(url))
            {
                onLoaded(null);
                return;
            }

            UnityWebRequest request = UnityWebRequestTexture.GetTexture(url, true);
            request.SetRequestHeader("User-Agent", UserAgent);
            request.timeout = TimeoutSeconds;

            request.SendWebRequest().completed += _ =>
            {
                Texture2D texture = null;
                string contentType = request.GetResponseHeader("Content-Type") ?? "";
                if (request.result == UnityWebRequest.Result.Success && contentType.StartsWith("image/"))
                {
                    texture = DownloadHandlerTexture.GetContent(request);
                    if (texture != null && texture.width <= BrokenTextureSize && texture.height <= BrokenTextureSize)
                    {
                        UnityEngine.Object.Destroy(texture);
                        texture = null;
                    }
                }
                request.Dispose();
                onLoaded(texture);
            };
        }
    }
}

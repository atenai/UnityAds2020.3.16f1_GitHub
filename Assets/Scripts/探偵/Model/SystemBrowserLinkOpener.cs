using System;
using UnityEngine;

namespace 探偵
{
    /// <summary>
    /// PCの既定のブラウザで開く。URLはAIが書いたものなので、http/https以外（file: など）は開かない。
    /// </summary>
    public sealed class SystemBrowserLinkOpener : ILinkOpener
    {
        public void Open(string url)
        {
            if (!IsWebUrl(url))
            {
                Debug.LogWarning("[探偵] Webページ以外のURLは開きません: " + url);
                return;
            }
            Application.OpenURL(url);
        }

        public static bool IsWebUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uri)
                && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        }
    }
}

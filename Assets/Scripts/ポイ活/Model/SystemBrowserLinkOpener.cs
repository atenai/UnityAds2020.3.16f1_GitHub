using UnityEngine;

namespace ポイ活
{
    /// <summary>
    /// 既定のブラウザで開くだけ。ログインはブラウザに残っているセッションに任せる。
    /// アプリはパスワードを持たないし、送信もしない。
    /// </summary>
    public sealed class SystemBrowserLinkOpener : ILinkOpener
    {
        public void Open(string url)
        {
            if (string.IsNullOrEmpty(url)) return;

            Application.OpenURL(url);
        }
    }
}

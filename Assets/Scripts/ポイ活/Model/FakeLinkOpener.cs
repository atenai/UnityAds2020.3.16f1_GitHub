using UnityEngine;

namespace ポイ活
{
    /// <summary>本当にブラウザを開かずログだけ出す。動作確認用。</summary>
    public sealed class FakeLinkOpener : ILinkOpener
    {
        public void Open(string url)
        {
            Debug.Log("[ポイ活] 開く: " + url);
        }
    }
}

using UnityEngine;

namespace ポイ活
{
    /// <summary>Consoleに出すだけの通知。動作確認用。</summary>
    public sealed class DebugLogNotifier : ITaskNotifier
    {
        public void Notify(string title, string message)
        {
            Debug.Log("[ポイ活] " + title + " : " + message);
        }
    }
}

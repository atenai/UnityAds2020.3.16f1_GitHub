using UnityEngine;

namespace 商品券
{
    public sealed class DebugLogNotifier : INotifier
    {
        public void Notify(string title, string message)
        {
            Debug.Log("[商品券] " + title + " : " + message);
        }
    }
}

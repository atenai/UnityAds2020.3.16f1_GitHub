namespace ポイ活
{
    /// <summary>アプリ内のバナーに出す通知。</summary>
    public sealed class InAppNotifier : ITaskNotifier
    {
        readonly PoikatsuView _view;

        public InAppNotifier(PoikatsuView view)
        {
            _view = view;
        }

        public void Notify(string title, string message)
        {
            _view.ShowBanner(title, message);
        }
    }
}

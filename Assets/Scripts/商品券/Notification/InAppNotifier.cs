namespace 商品券
{
    /// <summary>アプリ内のバナーに出す通知。</summary>
    public sealed class InAppNotifier : INotifier
    {
        readonly GiftCardView _view;

        public InAppNotifier(GiftCardView view)
        {
            _view = view;
        }

        public void Notify(string title, string message)
        {
            _view.ShowBanner(title, message);
        }
    }
}

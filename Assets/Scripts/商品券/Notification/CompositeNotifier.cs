namespace 商品券
{
    public sealed class CompositeNotifier : INotifier
    {
        readonly INotifier[] _notifiers;

        public CompositeNotifier(params INotifier[] notifiers)
        {
            _notifiers = notifiers;
        }

        public void Notify(string title, string message)
        {
            foreach (INotifier notifier in _notifiers) notifier.Notify(title, message);
        }
    }
}

namespace ポイ活
{
    /// <summary>複数の通知先へまとめて流す。</summary>
    public sealed class CompositeNotifier : ITaskNotifier
    {
        readonly ITaskNotifier[] _notifiers;

        public CompositeNotifier(params ITaskNotifier[] notifiers)
        {
            _notifiers = notifiers;
        }

        public void Notify(string title, string message)
        {
            foreach (ITaskNotifier notifier in _notifiers) notifier.Notify(title, message);
        }
    }
}

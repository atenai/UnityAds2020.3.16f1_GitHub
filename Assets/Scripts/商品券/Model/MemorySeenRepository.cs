namespace 商品券
{
    /// <summary>保存しない差し替え用。毎回すべて新着扱いになる。</summary>
    public sealed class MemorySeenRepository : ISeenRepository
    {
        SeenStore _store = new SeenStore();

        public SeenStore Load()
        {
            return _store;
        }

        public void Save(SeenStore store)
        {
            _store = store;
        }
    }
}

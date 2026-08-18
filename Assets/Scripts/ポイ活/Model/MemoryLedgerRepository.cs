namespace ポイ活
{
    /// <summary>ファイルに書かない差し替え用。</summary>
    public sealed class MemoryLedgerRepository : ILedgerRepository
    {
        PointLedger _ledger = new PointLedger();

        public PointLedger Load()
        {
            return _ledger;
        }

        public void Save(PointLedger ledger)
        {
            _ledger = ledger;
        }
    }
}

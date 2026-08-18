namespace ポイ活
{
    public interface ILedgerRepository
    {
        PointLedger Load();

        void Save(PointLedger ledger);
    }
}

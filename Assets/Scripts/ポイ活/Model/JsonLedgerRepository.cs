using System.IO;
using UnityEngine;

namespace ポイ活
{
    public sealed class JsonLedgerRepository : ILedgerRepository
    {
        static string FilePath => Path.Combine(Application.persistentDataPath, "poikatsu_ledger.json");

        public PointLedger Load()
        {
            if (!File.Exists(FilePath)) return new PointLedger();

            PointLedger ledger = JsonUtility.FromJson<PointLedger>(File.ReadAllText(FilePath));
            return ledger ?? new PointLedger();
        }

        public void Save(PointLedger ledger)
        {
            File.WriteAllText(FilePath, JsonUtility.ToJson(ledger, true));
        }
    }
}

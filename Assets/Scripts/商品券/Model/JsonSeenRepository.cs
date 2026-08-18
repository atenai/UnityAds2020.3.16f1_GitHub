using System.IO;
using UnityEngine;

namespace 商品券
{
    public sealed class JsonSeenRepository : ISeenRepository
    {
        static string FilePath => Path.Combine(Application.persistentDataPath, "giftcard_seen.json");

        public SeenStore Load()
        {
            if (!File.Exists(FilePath)) return new SeenStore();

            SeenStore store = JsonUtility.FromJson<SeenStore>(File.ReadAllText(FilePath));
            return store ?? new SeenStore();
        }

        public void Save(SeenStore store)
        {
            File.WriteAllText(FilePath, JsonUtility.ToJson(store, true));
        }
    }
}

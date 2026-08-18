using UnityEngine;

namespace ポイ活
{
    public sealed class PlayerPrefsSettingsRepository : ISettingsRepository
    {
        const string Key = "poikatsu_auto_open";

        public AutoOpenSettings Load()
        {
            string json = PlayerPrefs.GetString(Key, "");
            if (string.IsNullOrEmpty(json)) return new AutoOpenSettings();

            AutoOpenSettings settings = JsonUtility.FromJson<AutoOpenSettings>(json);
            return settings ?? new AutoOpenSettings();
        }

        public void Save(AutoOpenSettings settings)
        {
            PlayerPrefs.SetString(Key, JsonUtility.ToJson(settings));
            PlayerPrefs.Save();
        }
    }
}

namespace ポイ活
{
    /// <summary>保存しない差し替え用。</summary>
    public sealed class MemorySettingsRepository : ISettingsRepository
    {
        AutoOpenSettings _settings = new AutoOpenSettings();

        public AutoOpenSettings Load()
        {
            return _settings;
        }

        public void Save(AutoOpenSettings settings)
        {
            _settings = settings;
        }
    }
}

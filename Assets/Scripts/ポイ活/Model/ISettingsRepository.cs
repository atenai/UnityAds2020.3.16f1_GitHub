namespace ポイ活
{
    public interface ISettingsRepository
    {
        AutoOpenSettings Load();

        void Save(AutoOpenSettings settings);
    }
}

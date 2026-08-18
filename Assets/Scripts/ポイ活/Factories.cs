namespace ポイ活
{
    public static class Factories
    {
        public static ITaskRepository CreateRepository()
        {
            return new JsonTaskRepository();
            //return new MemoryTaskRepository();
        }

        public static ILedgerRepository CreateLedgerRepository()
        {
            return new JsonLedgerRepository();
            //return new MemoryLedgerRepository();
        }

        public static ISettingsRepository CreateSettingsRepository()
        {
            return new PlayerPrefsSettingsRepository();
            //return new MemorySettingsRepository();
        }

        public static ILinkOpener CreateLinkOpener()
        {
            return new SystemBrowserLinkOpener();
            //return new FakeLinkOpener();   // 本当にブラウザを開かず確認したいとき
        }

        public static ITaskNotifier CreateNotifier(PoikatsuView view)
        {
            return new CompositeNotifier(new InAppNotifier(view), new DebugLogNotifier());
            // Androidの端末通知を足すときは、ITaskNotifierの実装をここに追加する。
        }
    }
}

namespace ポイ活
{
    /// <summary>ファイルに書かない差し替え用。動作確認やテストで使う。</summary>
    public sealed class MemoryTaskRepository : ITaskRepository
    {
        TaskProgress _progress = new TaskProgress();

        public TaskProgress Load()
        {
            return _progress;
        }

        public void Save(TaskProgress progress)
        {
            _progress = progress;
        }
    }
}

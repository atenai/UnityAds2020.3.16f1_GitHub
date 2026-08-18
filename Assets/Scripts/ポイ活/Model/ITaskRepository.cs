namespace ポイ活
{
    public interface ITaskRepository
    {
        TaskProgress Load();

        void Save(TaskProgress progress);
    }
}

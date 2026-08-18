using System.IO;
using UnityEngine;

namespace ポイ活
{
    public sealed class JsonTaskRepository : ITaskRepository
    {
        static string FilePath => Path.Combine(Application.persistentDataPath, "poikatsu_progress.json");

        public TaskProgress Load()
        {
            if (!File.Exists(FilePath)) return new TaskProgress();

            TaskProgress progress = JsonUtility.FromJson<TaskProgress>(File.ReadAllText(FilePath));
            return progress ?? new TaskProgress();
        }

        public void Save(TaskProgress progress)
        {
            File.WriteAllText(FilePath, JsonUtility.ToJson(progress, true));
        }
    }
}

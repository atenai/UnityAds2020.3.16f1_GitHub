using System.Collections.Generic;
using UnityEngine;

namespace ポイ活
{
    /// <summary>登録したポイ活タスクの一覧。Inspectorで編集する。</summary>
    [CreateAssetMenu(fileName = "TaskCatalog", menuName = "ポイ活/Task Catalog")]
    public class TaskCatalog : ScriptableObject
    {
        [SerializeField] List<TaskDefinition> tasks = new List<TaskDefinition>();

        public IReadOnlyList<TaskDefinition> Tasks => tasks;

        public void Add(TaskDefinition definition)
        {
            tasks.Add(definition);
        }

        public void ReplaceAll(IEnumerable<TaskDefinition> definitions)
        {
            tasks.Clear();
            tasks.AddRange(definitions);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace 商品券
{
    /// <summary>購読するフィードの一覧。Inspectorで編集する。</summary>
    [CreateAssetMenu(fileName = "FeedCatalog", menuName = "商品券/Feed Catalog")]
    public class FeedCatalog : ScriptableObject
    {
        [SerializeField] List<FeedDefinition> feeds = new List<FeedDefinition>();

        public IReadOnlyList<FeedDefinition> Feeds => feeds;

        public void ReplaceAll(IEnumerable<FeedDefinition> definitions)
        {
            feeds.Clear();
            feeds.AddRange(definitions);
        }
    }
}

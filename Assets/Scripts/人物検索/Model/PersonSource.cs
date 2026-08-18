namespace 人物検索
{
    /// <summary>
    /// 検索先の情報源。どのWikipediaを引くかと、Wikidata側でどの種類の項目に絞るかの組。
    /// 別APIの情報源を足したいときは IPersonSearchService を別実装にする。
    /// </summary>
    public class PersonSource
    {
        public string Id { get; }
        public string DisplayName { get; }
        public string Host { get; }

        /// <summary>SPARQLの絞り込み条件。?item を束縛する。</summary>
        public string EntityFilter { get; }

        public PersonSource(string id, string displayName, string host, string entityFilter)
        {
            Id = id;
            DisplayName = displayName;
            Host = host;
            EntityFilter = entityFilter;
        }
    }
}

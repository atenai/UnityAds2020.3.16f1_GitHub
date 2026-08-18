using System;

namespace 人物検索
{
    // Wikipedia API を formatversion=2 で叩いたときの形。
    // pages がオブジェクトではなく配列になるので JsonUtility でそのまま読める。
    //
    // 注意: JsonUtility は JSON に無い入れ子オブジェクトも空インスタンスで埋める。
    // null 判定ではなく中身の有無で見ること。
    [Serializable]
    public class WikipediaResponse
    {
        public WikipediaQuery query;
        public WikipediaError error;
    }

    [Serializable]
    public class WikipediaQuery
    {
        public WikipediaPage[] pages;
    }

    [Serializable]
    public class WikipediaPage
    {
        public int pageid;
        public int index;
        public string title;
        public string description;
        public string extract;
        public WikipediaPageProps pageprops;
    }

    [Serializable]
    public class WikipediaPageProps
    {
        public string wikibase_item;
    }

    [Serializable]
    public class WikipediaError
    {
        public string code;
        public string info;
    }

    // Wikidata Query Service (SPARQL) の応答。
    [Serializable]
    public class SparqlResponse
    {
        public SparqlResults results;
    }

    [Serializable]
    public class SparqlResults
    {
        public SparqlBinding[] bindings;
    }

    [Serializable]
    public class SparqlBinding
    {
        public SparqlValue item;
    }

    [Serializable]
    public class SparqlValue
    {
        public string value;
    }
}

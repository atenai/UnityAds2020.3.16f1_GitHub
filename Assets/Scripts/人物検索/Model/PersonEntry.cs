namespace 人物検索
{
    /// <summary>表の1行にあたる人物データ。</summary>
    public class PersonEntry
    {
        public int Order { get; }
        public string Name { get; }
        public string Description { get; }
        public string Summary { get; }
        public string Url { get; }
        public string ImageUrl { get; }

        public PersonEntry(int order, string name, string description, string summary, string url, string imageUrl)
        {
            Order = order;
            Name = name;
            Description = description;
            Summary = summary;
            Url = url;
            ImageUrl = imageUrl;
        }
    }
}

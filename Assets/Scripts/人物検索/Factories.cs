namespace 人物検索
{
    public static class Factories
    {
        public static IPersonSearchService CreateSearchService()
        {
            return new WikipediaPersonSearchService();
            //return new FakePersonSearchService();
        }
    }
}

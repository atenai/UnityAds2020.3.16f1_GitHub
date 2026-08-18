using UnityEngine;

namespace 人物検索
{
    public static class Factories
    {
        public static IPersonSearchService CreateSearchService()
        {
            return new WikipediaPersonSearchService();
            //return new FakePersonSearchService();
        }

        public static IImageLoader CreateImageLoader(MonoBehaviour runner)
        {
            return new WebImageLoader(runner);
            //return new NullImageLoader();
        }
    }
}

namespace 商品券
{
    public static class Factories
    {
        public static IFeedService CreateFeedService()
        {
            return new RssFeedService();
            //return new FakeFeedService();
        }

        public static ISeenRepository CreateSeenRepository()
        {
            return new JsonSeenRepository();
            //return new MemorySeenRepository();   // 毎回すべて新着にしたいとき
        }

        public static INotifier CreateNotifier(GiftCardView view)
        {
            return new CompositeNotifier(new InAppNotifier(view), new DebugLogNotifier());
        }
    }
}

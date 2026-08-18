using System;
using System.Collections.Generic;

namespace 商品券
{
    /// <summary>ネットに繋がずに表示を確認するための差し替え用。</summary>
    public sealed class FakeFeedService : IFeedService
    {
        public void FetchAllAsync(IReadOnlyList<FeedDefinition> feeds,
            Action<List<GiftCardItem>, List<string>> onCompleted)
        {
            List<GiftCardItem> items = new List<GiftCardItem>();
            for (int i = 1; i <= 8; i++)
            {
                items.Add(new GiftCardItem("fake-" + i, "ダミーの商品券キャンペーン " + i, "テスト媒体",
                    "", DateTime.Now.AddHours(-i), "ダミーフィード"));
            }
            onCompleted(items, new List<string>());
        }
    }
}

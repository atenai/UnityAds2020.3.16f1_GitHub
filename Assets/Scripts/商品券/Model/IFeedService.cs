using System;
using System.Collections.Generic;

namespace 商品券
{
    public interface IFeedService
    {
        /// <summary>全フィードを順に取り、まとめて返す。取れなかったフィードは errors に理由が入る。</summary>
        void FetchAllAsync(IReadOnlyList<FeedDefinition> feeds, Action<List<GiftCardItem>, List<string>> onCompleted);
    }
}

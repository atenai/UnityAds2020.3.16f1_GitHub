using UnityEngine;

namespace 商品券
{
    public class Main : MonoBehaviour
    {
        [SerializeField] FeedCatalog feedCatalog;
        [SerializeField] GiftCardView giftCardView;

        GiftCardPresenter _presenter;

        void Start()
        {
            GiftCardModel model = new GiftCardModel(feedCatalog, Factories.CreateFeedService(),
                Factories.CreateSeenRepository());
            _presenter = new GiftCardPresenter(model, giftCardView, Factories.CreateNotifier(giftCardView));
        }
    }
}

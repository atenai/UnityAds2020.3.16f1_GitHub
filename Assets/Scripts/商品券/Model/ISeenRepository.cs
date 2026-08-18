namespace 商品券
{
    public interface ISeenRepository
    {
        SeenStore Load();

        void Save(SeenStore store);
    }
}

public sealed class ProductDummy : IProduct
{
    public Product GetData()
    {
        return new Product(1, "AAA", 100);
    }

    public bool IsReady()
    {
        return true;
    }
}

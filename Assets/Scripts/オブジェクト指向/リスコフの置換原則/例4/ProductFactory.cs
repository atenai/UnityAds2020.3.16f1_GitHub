public static class ProductFactory
{
    public static IProduct Create()
    {
        return new ProductDummy();
    }
}

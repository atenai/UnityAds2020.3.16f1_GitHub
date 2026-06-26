namespace MVPパターン
{
    public static class Factories
    {
        public static IProduct CreateProduct()
        {
            return new ProductFake();
            //return new ProductSqlServer();
        }
    }
}
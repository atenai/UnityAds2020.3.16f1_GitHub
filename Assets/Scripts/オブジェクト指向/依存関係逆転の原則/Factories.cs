namespace 依存関係逆転の原則
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
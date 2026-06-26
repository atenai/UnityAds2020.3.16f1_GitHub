namespace 依存関係逆転の原則
{
    public sealed class ProductSqlServer : IProduct
    {
        public string GetData()
        {
            return "AAA sql server";
        }

        public void Save(string value)
        {
            //Save
        }
    }
}
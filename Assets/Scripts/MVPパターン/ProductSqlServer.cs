namespace MVPパターン
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
namespace DIパターン
{
    public sealed class ProductMock : IProduct
    {
        public string GetData()
        {
            return "AAA";
        }

        public void Save(string value)
        {
            throw new System.NotImplementedException();
        }
    }
}
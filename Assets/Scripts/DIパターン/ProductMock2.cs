namespace DIパターン
{
    public sealed class ProductMock2 : IProduct
    {
        public string GetData()
        {
            return "AAABB";
        }

        public void Save(string value)
        {
            throw new System.NotImplementedException();
        }
    }
}
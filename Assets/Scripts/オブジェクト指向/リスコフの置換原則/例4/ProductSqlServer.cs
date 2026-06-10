public sealed class ProductSqlServer : IProduct
{
    public Product GetData()
    {
        throw new System.NotImplementedException();
    }

    public bool IsReady()
    {
        //SQLServerと接続チェック
        return true;
    }
}

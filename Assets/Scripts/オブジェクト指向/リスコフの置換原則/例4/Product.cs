public sealed class Product
{
    public int ProductId { get; }
    public string ProductName { get; }
    public int Price { get; }

    public Product(int productId, string productName, int price)
    {
        this.ProductId = productId;
        this.ProductName = productName;
        this.Price = price;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }

        var product = obj as Product;
        if (product == null)
        {
            return false;
        }

        if (product.ProductId != ProductId)
        {
            return false;
        }

        if (product.ProductName != ProductName)
        {
            return false;
        }

        if (product.Price != Price)
        {
            return false;
        }

        return true;
    }
}

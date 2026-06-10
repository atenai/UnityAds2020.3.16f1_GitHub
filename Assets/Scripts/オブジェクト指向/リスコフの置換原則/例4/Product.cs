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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects_ラムダ式
{
    public sealed class Product
    {
        public Product(int productId, string productName, int price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }

        public int ProductId { get; }
        public string ProductName { get; }
        public int Price { get; }
    }

    public sealed class ProductDto
    {
        public ProductDto(string productId, string productName)
        {
            ProductId = productId;
            ProductName = productName;
        }

        public ProductDto(Product product)
        {
            ProductId = product.ProductId.ToString();
            ProductName = product.ProductName;
        }

        public string ProductId { get; }
        public string ProductName { get; }

        public override string ToString()
        {
            return $"dto productId={ProductId} productName={ProductName}";
        }
    }

    public sealed class ProductEntity
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }

        public override string ToString()
        {
            return $"entity productId={ProductId} productName={ProductName}";
        }
    }
}
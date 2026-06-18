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
}
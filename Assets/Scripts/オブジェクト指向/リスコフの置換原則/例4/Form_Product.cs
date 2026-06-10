using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form_Product : MonoBehaviour
{
    private IProduct _product;

    void Awake()
    {
        _product = ProductFactory.Create();
    }

    void Start()
    {
        if (_product.IsReady() == true)
        {
            var entity = _product.GetData();
            Debug.Log(entity.ProductId);
            Debug.Log(entity.ProductName);
            Debug.Log(entity.Price);
        }
    }
}

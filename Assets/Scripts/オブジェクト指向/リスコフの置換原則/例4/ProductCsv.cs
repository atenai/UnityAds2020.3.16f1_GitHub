using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ProductCsv : IProduct
{
    public Product GetData()
    {
        throw new System.NotImplementedException();
    }

    public bool IsReady()
    {
        return true;
    }
}

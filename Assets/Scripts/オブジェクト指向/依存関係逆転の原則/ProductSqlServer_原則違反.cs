using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace 依存関係逆転の原則
{
    public sealed class ProductSqlServer_原則違反
    {
        public string GetData()
        {
            return "AAA sql server";
        }
    }
}
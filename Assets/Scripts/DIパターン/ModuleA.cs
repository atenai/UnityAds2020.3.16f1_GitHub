using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIパターン
{
    public class ModuleA
    {
        private IProduct _product;

        public ModuleA(IProduct product)
        {
            _product = product;
        }

        public string GetValue()
        {
            return _product.GetData() + "%";
        }

        public int GetAB(int a, int b)
        {
            return a + b;
        }
    }
}
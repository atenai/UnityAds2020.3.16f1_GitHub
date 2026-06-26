using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIパターン
{
    public class UnitTest1 : MonoBehaviour
    {
        void Start()
        {
            var m = new ModuleA(new ProductMock());
            Debug.Log(m.GetValue());
            Debug.Log(m.GetAB(1, 2));
        }
    }

    internal sealed class ProductMock : IProduct
    {
        public string GetData()
        {
            return "AAA";
        }

        public void Save(string value)
        {
            throw new System.NotImplementedException();
        }
    }
}
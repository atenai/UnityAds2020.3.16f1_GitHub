using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIパターン
{
    public class UnitTest1 : MonoBehaviour
    {
        void Start()
        {
            //クラスによる依存性の注入
            ModuleA m = new ModuleA(new ProductMock());
            Debug.Log(m.GetValue());

            //クラスによる依存性の注入
            ModuleA m2 = new ModuleA(new ProductMock2());
            Debug.Log(m2.GetValue());

            //関数による依存性の注入
            string value = ModuleB.GetValue(new ProductMock());
            Debug.Log(value);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace インターフェイス分離の原則
{
    public class Form1 : MonoBehaviour
    {
        //IDevice _device = new Z01();
        //IPrint _print = new Z01();
        IPrint _print = new Z02();
        IFax _fax = new Z02();
        IPrintFax _printFax = new Z02();// ← 推奨されない

        void Start()
        {
            _print.Print();
            _fax.Fax();
        }
    }
}
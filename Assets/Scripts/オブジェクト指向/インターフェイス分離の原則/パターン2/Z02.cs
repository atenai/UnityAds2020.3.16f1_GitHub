using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace インターフェイス分離の原則
{
    public class Z02 : /* IPrint, IFax */ IPrintFax
    {
        public void Fax()
        {
            Debug.Log("ファックス");
        }

        public void Print()
        {
            Debug.Log("プリント");
        }
    }
}
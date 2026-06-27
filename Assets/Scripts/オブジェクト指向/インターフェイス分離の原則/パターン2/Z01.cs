using UnityEngine;

namespace インターフェイス分離の原則
{
    public class Z01 : /* IDevice */ IPrint
    {
        public void Print()
        {
            Debug.Log("Print!");
        }

        // public void Fax()
        // {
        //     throw new System.NotImplementedException();
        // }

        // public void Scan()
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}
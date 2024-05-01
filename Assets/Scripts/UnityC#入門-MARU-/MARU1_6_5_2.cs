using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_6_5_2 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");
        B("関数の呼び出し成功");
    }

    void Update()
    {
        //Debug.Log("Update");
    }

    void B(string bbb)
    {
        Debug.Log(bbb);
    }
}

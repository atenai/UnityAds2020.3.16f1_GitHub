using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_5_3 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");

        int a = 10;
        int b = 100;

        b = ++a;
        //↓これと同じ
        //a = a + 1;
        //b = a;

        Debug.Log(a);
        Debug.Log(b);
    }

    void Update()
    {
        Debug.Log("Update");
    }
}

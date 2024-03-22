using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_2_5_4 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");

        int a = 10;
        int b = 100;

        b = a++;
        //↓これと同じ
        //b = a;
        //a = a + 1;

        Debug.Log(a);
        Debug.Log(b);
    }

    void Update()
    {
        Debug.Log("Update");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU2_4_1_1 : MonoBehaviour
{
    int a = 1000;

    void Start()
    {
        //Debug.Log("Start");

        int b = 100;

        Debug.Log(a);
        Debug.Log(b);

        C();
    }

    void Update()
    {
        //Debug.Log("Update");
    }

    void C()
    {
        Debug.Log("テスト");
    }
}

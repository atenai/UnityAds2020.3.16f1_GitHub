using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_1_9_1 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        //配列の初期化
        int[] scoreArray = { 10, 20, 30, 40, 50 };

        foreach (int a in scoreArray)
        {
            UnityEngine.Debug.Log(a);
        }
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

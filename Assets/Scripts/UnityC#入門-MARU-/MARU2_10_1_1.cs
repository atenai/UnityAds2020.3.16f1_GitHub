using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_10_1_1 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        int a = 10;

        do
        {
            UnityEngine.Debug.Log(a);
        } while (a == 100);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_6_7_2 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        D(ddd2: "ハロー", ddd3: 0.5f, ddd1: 100);
    }

    void Update()
    {
        //Debug.Log("Update");
    }

    void D(int ddd1, string ddd2, float ddd3)
    {
        Debug.Log(ddd1);
        Debug.Log(ddd2);
        Debug.Log(ddd3);
    }
}

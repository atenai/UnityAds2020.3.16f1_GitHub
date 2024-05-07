using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_6_7_1 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        D(100, "ハロー");
    }

    void Update()
    {
        //Debug.Log("Update");
    }

    void D(int ddd1, string ddd2)
    {
        Debug.Log(ddd1);
        Debug.Log(ddd2);
    }
}

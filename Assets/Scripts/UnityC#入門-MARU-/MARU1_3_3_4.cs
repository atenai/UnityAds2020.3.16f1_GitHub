using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_3_3_4 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");

        bool a = true;
        bool b = true;
        bool c = false;

        Debug.Log(a && b);
        Debug.Log(a && c);
    }

    void Update()
    {
        Debug.Log("Update");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_3_3_7 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");

        bool a = true;
        bool b = true;
        bool c = false;

        if (!a)
        {
            Debug.Log("➀呼び出し");
        }

        if (!c)
        {
            Debug.Log("➁呼び出し");
        }

        if (a && b)
        {
            Debug.Log("➂呼び出し");
        }

        if (a && c)
        {
            Debug.Log("➃呼び出し");
        }

        if (a && b && c)
        {
            Debug.Log("➄呼び出し");
        }

        if (a || b)
        {
            Debug.Log("➅呼び出し");
        }

        if (a || c)
        {
            Debug.Log("➆呼び出し");
        }

        if (a || b || c)
        {
            Debug.Log("➇呼び出し");
        }
    }

    void Update()
    {
        Debug.Log("Update");
    }
}

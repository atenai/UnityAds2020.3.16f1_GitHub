using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_3_6_1 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");

        int a = 3;

        if (a == 0)
        {
            Debug.Log("aは0です");
        }
        else if (a == 1)
        {
            Debug.Log("aは1です");
        }
        else if (a == 2)
        {
            Debug.Log("aは2です");
        }
        else if (a == 3)
        {
            Debug.Log("aは3です");
        }
        else
        {
            Debug.Log("aは0,1,2,3以外です");
        }
    }

    void Update()
    {
        Debug.Log("Update");
    }
}

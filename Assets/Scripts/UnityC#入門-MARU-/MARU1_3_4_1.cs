using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_3_4_1 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");

        int a = 10;
        int b = 100;

        if (a == b)
        {
            Debug.Log("aとbは同じです");
        }
        else
        {
            Debug.Log("aとbは異なります");
        }
    }

    void Update()
    {
        Debug.Log("Update");
    }
}

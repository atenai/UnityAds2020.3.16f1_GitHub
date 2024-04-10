using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_4_2_1 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        int a = 10;

        while (a < 100)
        {
            a += 20;
            Debug.Log("aに20をプラス a=" + a);
        }
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_3_1_3 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");

        Debug.Log(10 == 100);
        Debug.Log(10 != 100);
        Debug.Log(10 < 100);
        Debug.Log(10 > 100);
        Debug.Log(10 <= 100);
        Debug.Log(10 >= 100);
    }

    void Update()
    {
        Debug.Log("Update");
    }
}

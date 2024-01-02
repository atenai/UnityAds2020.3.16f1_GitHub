using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class MARU1 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");
    }

    void Update()
    {
        Debug.Log("Update");

        int a = 10;

        //aに3をプラス
        a += 3;
        Debug.Log(a);

        //aから2をマイナス
        a -= 2;
        Debug.Log(a);
    }
}

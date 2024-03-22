using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_5_1 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");

        int a = 10;

        //aに3をプラス
        a += 3;
        Debug.Log(a);

        //aから2をマイナス
        a -= 2;
        Debug.Log(a);
    }

    void Update()
    {
        Debug.Log("Update");
    }
}

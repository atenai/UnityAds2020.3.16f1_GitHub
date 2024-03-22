using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_2_6_2 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");

        //string型の変数を宣言
        string a;
        string b;

        a = "Aさん";
        b = "りんご";
        Debug.Log(a + "は" + b + "が好きです。");

        a = "B君";
        b = "メロン";
        Debug.Log(a + "は" + b + "が好きです。");
    }

    void Update()
    {
        Debug.Log("Update");
    }
}

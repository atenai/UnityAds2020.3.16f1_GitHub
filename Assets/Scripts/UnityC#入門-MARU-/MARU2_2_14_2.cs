using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_2_14_2 : MonoBehaviour
{
    //GameObject型の変数TestObjectを宣言
    private GameObject TestObject;

    void Start()
    {
        //Debug.Log("Start");

        TestObject = GameObject.Find("CubeA");

        //非表示にする
        TestObject.SetActive(false);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

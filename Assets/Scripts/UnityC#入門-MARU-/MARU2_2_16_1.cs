using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_2_16_1 : MonoBehaviour
{
    //GameObject型の変数TestObjectを宣言
    private GameObject TestObject;

    void Start()
    {
        //Debug.Log("Start");

        //CubeAという名前のGameObjectを取得
        TestObject = GameObject.Find("CubeA");

        //TestObjectに割り当てられているGameObjectを生成
        Instantiate(TestObject);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

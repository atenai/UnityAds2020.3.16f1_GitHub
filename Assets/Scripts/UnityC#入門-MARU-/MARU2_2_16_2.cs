using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_2_16_2 : MonoBehaviour
{
    //GameObject型の変数TestObjectを宣言
    private GameObject TestObject;

    void Start()
    {
        //Debug.Log("Start");

        //CubeAという名前のGameObjectを取得
        TestObject = GameObject.Find("CubeA");

        //TestObjectに割り当てられているGameObjectを生成
        //位置はx = 1.5 y = 0 z = 0
        //回転は無し
        Instantiate(TestObject, new UnityEngine.Vector3(1.5f, 0.0f, 0.0f), Quaternion.identity);

        //TestObjectに割り当てられているGameObjectを生成
        //位置はx = -1.5 y = 0 z = 0
        //回転はx = 0 y = 45 z = 0
        Instantiate(TestObject, new UnityEngine.Vector3(-1.5f, 0.0f, 0.0f), Quaternion.Euler(0.0f, 45.0f, 0.0f));
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

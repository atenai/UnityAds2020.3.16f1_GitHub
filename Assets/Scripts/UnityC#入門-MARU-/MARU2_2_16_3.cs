using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_2_16_3 : MonoBehaviour
{
    //GameObject型の変数TestObjectを宣言
    private GameObject TestObject;

    //GameObject型の変数abcを宣言
    private GameObject abc;

    void Start()
    {
        //Debug.Log("Start");

        //CubeAという名前のGameObjectを取得
        TestObject = GameObject.Find("CubeA");

        //TestObjectに割り当てられているGameObjectを生成し、変数abcに割り当て
        //位置はx = 1.5 y = 0 z = 0
        //回転は無し
        abc = Instantiate(TestObject, new UnityEngine.Vector3(1.5f, 0.0f, 0.0f), Quaternion.identity);

        abc.name = "abc";
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

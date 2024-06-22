using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_2_4_1 : MonoBehaviour
{
    //GameObject型の変数TestObjectを宣言
    public GameObject TestObject;

    void Start()
    {
        //Debug.Log("Start");

        //Vector3型の変数aを宣言
        Vector3 a;

        //変数aにVector3型のインスタンスを生成
        a = new Vector3();

        //aが持つx,y,zの情報にデータを割り当て
        a.x = 1.0f;
        a.y = 10.0f;
        a.z = 100.0f;

        //localPositionへ変数aのデータを割り当て
        TestObject.transform.localPosition = a;
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

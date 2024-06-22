using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_2_4_2 : MonoBehaviour
{
    //GameObject型の変数TestObjectを宣言
    public GameObject TestObject;

    void Start()
    {
        //Debug.Log("Start");

        //Vector3型の変数aを宣言、データを割り当て
        Vector3 a = new Vector3(1.0f, 10.0f, 100.0f);

        //localPositionへ変数aのデータを割り当て
        TestObject.transform.localPosition = a;
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

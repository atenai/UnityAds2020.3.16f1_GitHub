using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_2_3_1 : MonoBehaviour
{
    //GameObject型の変数TestObjectを宣言
    public GameObject TestObject;

    void Start()
    {
        //Debug.Log("Start");

        TestObject.transform.Translate(1.0f, 10.0f, 100.0f);

    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

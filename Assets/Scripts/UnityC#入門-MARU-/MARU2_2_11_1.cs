using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_2_11_1 : MonoBehaviour
{
    //GameObject型の変数TestObjectを宣言
    public GameObject TestObject;

    void Start()
    {
        //Debug.Log("Start");

        UnityEngine.Debug.Log(TestObject.activeInHierarchy);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

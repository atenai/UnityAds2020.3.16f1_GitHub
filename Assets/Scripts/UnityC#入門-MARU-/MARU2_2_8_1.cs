using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_2_8_1 : MonoBehaviour
{
    //GameObject型の変数TestObjectを宣言
    public GameObject TestObject;

    void Start()
    {
        //Debug.Log("Start");

        UnityEngine.Debug.Log("位置情報 = " + TestObject.transform.localPosition);
        UnityEngine.Debug.Log("回転情報 = " + TestObject.transform.localEulerAngles);
        UnityEngine.Debug.Log("スケール情報 = " + TestObject.transform.localScale);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

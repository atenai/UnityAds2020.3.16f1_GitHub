using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_2_8_2 : MonoBehaviour
{
    //GameObject型の変数TestObjectを宣言
    public GameObject TestObject;

    void Start()
    {
        //Debug.Log("Start");

        UnityEngine.Debug.Log("位置情報X = " + TestObject.transform.localPosition.x);
        UnityEngine.Debug.Log("位置情報Y = " + TestObject.transform.localPosition.y);
        UnityEngine.Debug.Log("位置情報Z = " + TestObject.transform.localPosition.z);

        UnityEngine.Debug.Log("回転情報X = " + TestObject.transform.localEulerAngles.x);
        UnityEngine.Debug.Log("回転情報Y = " + TestObject.transform.localEulerAngles.y);
        UnityEngine.Debug.Log("回転情報Z = " + TestObject.transform.localEulerAngles.z);

        UnityEngine.Debug.Log("スケール情報X = " + TestObject.transform.localScale.x);
        UnityEngine.Debug.Log("スケール情報Y = " + TestObject.transform.localScale.y);
        UnityEngine.Debug.Log("スケール情報Z = " + TestObject.transform.localScale.z);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

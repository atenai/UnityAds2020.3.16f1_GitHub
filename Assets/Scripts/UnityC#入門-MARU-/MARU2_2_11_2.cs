using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_2_11_2 : MonoBehaviour
{
    //GameObject型の変数TestObjectを宣言
    public GameObject TestObject;

    void Start()
    {
        //Debug.Log("Start");

        UnityEngine.Debug.Log("CubeA activeInHierarchy = " + TestObject.activeInHierarchy);//ヒエラルキー上での表示状態を知ることができる
        UnityEngine.Debug.Log("CubeA activeSelf = " + TestObject.activeSelf);//ゲームオブジェクト自身の純粋な表示状態を知ることができる

    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

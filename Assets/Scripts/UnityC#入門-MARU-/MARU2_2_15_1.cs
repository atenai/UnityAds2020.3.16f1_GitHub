using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_2_15_1 : MonoBehaviour
{
    //GameObject型の変数TestObjectを宣言
    private GameObject TestObject;

    //Transform型の変数aaaTransformを宣言
    private Transform aaaTransform;

    void Start()
    {
        //Debug.Log("Start");

        //CubeAという名前のGameObjectを取得
        TestObject = GameObject.Find("CubeA");

        //CubeAのTransform型の関数Find()を使用し、AAAという名前のオブジェクトのTransform型を取得する
        //取得したTransform型を変数aaaTransformへ割り当て
        aaaTransform = TestObject.transform.Find("AAA");

        //位置を変更
        aaaTransform.Translate(1, 2, 3);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

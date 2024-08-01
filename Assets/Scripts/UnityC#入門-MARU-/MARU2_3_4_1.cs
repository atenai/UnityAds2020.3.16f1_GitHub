using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq.Expressions;

public class MARU2_3_4_1 : MonoBehaviour
{
    //GameObject型の変数aを宣言
    private GameObject a;

    //BoxCollider型の変数bを宣言
    private BoxCollider b;

    void Start()
    {
        //Debug.Log("Start");

        //CubeAのGameObject型を取得し変数aへ割り当て
        a = GameObject.Find("CubeA");

        //変数aのGameObject型からBoxCollider型を取得
        //取得したBoxCollider型を変数bへ割り当て
        b = a.GetComponent<BoxCollider>();

        //BoxCollider型の変数sizeを変更
        b.size = new Vector3(10.0f, 10.0f, 10.0f);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

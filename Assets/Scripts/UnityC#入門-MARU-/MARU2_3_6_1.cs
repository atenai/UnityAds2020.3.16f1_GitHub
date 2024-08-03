using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq.Expressions;

public class MARU2_3_6_1 : MonoBehaviour
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

        //変数bへBoxCollider型を割り当て
        b = a.GetComponent<BoxCollider>();

        //コンポーネントを削除
        Destroy(b);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

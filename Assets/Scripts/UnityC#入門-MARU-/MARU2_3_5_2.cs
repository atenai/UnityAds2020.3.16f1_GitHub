using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq.Expressions;

public class MARU2_3_5_2 : MonoBehaviour
{
    //GameObject型の変数aを宣言
    private GameObject a;

    //Rigidbody型の変数bを宣言
    private Rigidbody b;

    void Start()
    {
        //Debug.Log("Start");

        //CubeAのGameObject型を取得し変数aへ割り当て
        a = GameObject.Find("CubeA");

        //aのGameObject型へRigidbodyコンポーネントを追加
        //変数bへRigidbody型を割り当て
        b = a.AddComponent<Rigidbody>();

        //変数bのRigidbody型の変数massを変更
        b.mass = 5.0f;
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

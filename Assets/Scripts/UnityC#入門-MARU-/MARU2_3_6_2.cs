using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq.Expressions;

public class MARU2_3_6_2 : MonoBehaviour
{
    //GameObject型の変数aを宣言
    private GameObject a;

    void Start()
    {
        //Debug.Log("Start");

        //CubeAのGameObject型を取得し変数aへ割り当て
        a = GameObject.Find("CubeA");

        //BoxCollider型を取得
        //取得したコンポーネントを削除
        Destroy(a.GetComponent<BoxCollider>());
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

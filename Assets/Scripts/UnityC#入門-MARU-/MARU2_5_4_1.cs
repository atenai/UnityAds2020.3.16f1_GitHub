using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU2_5_4_1 : MonoBehaviour
{
    void OnDestroy()
    {
        Debug.Log("OnDestroy関数が呼び出されました");
    }

    void Start()
    {
        //Debug.Log("Start関数呼び出し");

        //本スクリプトが割りついているGameObject型を削除
        Destroy(gameObject);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

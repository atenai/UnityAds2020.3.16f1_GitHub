using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU2_5_2_2 : MonoBehaviour
{
    //Awakeはスクリプトを非アクティブにしても呼び出される
    void Awake()
    {
        //Debug.Log("Awake関数呼び出し");
    }

    void OnEnable()
    {
        Debug.Log("OnEnable関数が呼び出されました");
    }

    void Start()
    {
        //Debug.Log("Start関数呼び出し");

        //本スクリプトが割りついているGameObject型を非アクティブ化
        gameObject.SetActive(false);

        //本スクリプトが割りついているGameObject型をアクティブ化
        gameObject.SetActive(true);

        //本スクリプトを非アクティブ化
        enabled = false;

        //本スクリプトをアクティブ化
        enabled = true;
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_1_8_5 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        //List 初期化
        List<int> scoreList = new List<int>() { 10, 20, 30, 40, 50 };

        //挿入
        scoreList.RemoveAt(2);

        //List 全要素の確認
        for (int i = 0; i < scoreList.Count; i++)
        {
            UnityEngine.Debug.Log("Listの要素 = " + scoreList[i]);
        }
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

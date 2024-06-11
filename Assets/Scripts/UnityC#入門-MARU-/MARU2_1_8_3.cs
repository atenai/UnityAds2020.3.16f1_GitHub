using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_1_8_3 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        //配列 初期化
        int[] scoreArray = { 10, 20, 30, 40, 50 };

        //配列 要素2の確認
        UnityEngine.Debug.Log("配列の要素2 = " + scoreArray[2]);

        //配列 全要素の確認
        for (int i = 0; i < scoreArray.Length; i++)
        {
            UnityEngine.Debug.Log("配列の要素 = " + scoreArray[i]);
        }

        //List 初期化
        List<int> scoreList = new List<int>() { 10, 20, 30, 40, 50 };

        //List 要素2の確認
        UnityEngine.Debug.Log("Listの要素2 = " + scoreList[2]);

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

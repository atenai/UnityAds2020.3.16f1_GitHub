using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_11_1_2 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        int a = 10;

        //if～else if～else文基本構文
        if (a == 100)
        {
            UnityEngine.Debug.Log("テスト");
        }
        else if (a == 1000)
        {
            UnityEngine.Debug.Log("テスト");
        }
        else
        {
            UnityEngine.Debug.Log("テスト");
        }

        //処理内容が一行のみの時ブロック{}を省略できる
        if (a == 100)
            UnityEngine.Debug.Log("テスト");
        else if (a == 1000)
            UnityEngine.Debug.Log("テスト");
        else
            UnityEngine.Debug.Log("テスト");

        //処理内容が一行のみの時ブロック{}を省略できる 真横に書ける
        if (a == 100) UnityEngine.Debug.Log("テスト");
        else if (a == 1000) UnityEngine.Debug.Log("テスト");
        else UnityEngine.Debug.Log("テスト");
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU2_5_5_2 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start関数呼び出し");

        //30FPSへ設定
        //Application.targetFrameRate = 30;

        //設定可能な最大のフレームレートへ設定
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }

    void Update()
    {
        //Debug.Log("Update");

        Debug.Log("テストです");
    }
}

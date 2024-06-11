using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_1_12_1 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

#if UNITY_ANDROID//Androidの場合の処理

//Androidの処理を書く

#endif//Androidの処理範囲終了

#if UNITY_IOS//iOSの場合の処理

//iOSの処理を書く

#endif//iOSの処理範囲終了
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

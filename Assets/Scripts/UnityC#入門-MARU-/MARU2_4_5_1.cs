using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU2_4_5_1 : MonoBehaviour
{
    //AudioSource型の変数Aを宣言
    public AudioSource A;

    void Start()
    {
        //Debug.Log("Start");

        //AudioSource型の関数Play()を実行
        A.Play();
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

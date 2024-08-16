using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU2_4_6_1 : MonoBehaviour
{
    //AudioSource型の変数Aを宣言
    public AudioSource A;

    //AudioClip型の変数Bを宣言
    public AudioClip B;

    void Start()
    {
        //Debug.Log("Start");

        //AudioSource型の関数PlayOneShot()を実行
        A.PlayOneShot(B);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

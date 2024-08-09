using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU2_4_2_1 : MonoBehaviour
{
    //Text型の変数Aを宣言
    public Text A;

    void Start()
    {
        //Debug.Log("Start");

        //Text型の変数text(string型)にデータを割り当て
        A.text = "AB\nCD\nE";
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

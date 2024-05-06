using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_6_6_3 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        //返り値をコンソールに表示
        Debug.Log(C(5));
    }

    void Update()
    {
        //Debug.Log("Update");
    }

    float C(int ccc)
    {
        //float型の変数を宣言　変数名はnumber
        float number;

        //引数の変数を1.5倍したデータをnumberへ割り当て
        number = ccc * 1.5f;

        //返り値としてnumberのデータを返す
        return number;
    }
}

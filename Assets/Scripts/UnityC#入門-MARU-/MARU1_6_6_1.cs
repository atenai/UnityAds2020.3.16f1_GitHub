using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_6_6_1 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        //float型の変数を宣言　変数名はx
        float x;

        //変数名xへ関数名Cの返り値データを割り当てる
        x = C(5);

        Debug.Log(x);
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

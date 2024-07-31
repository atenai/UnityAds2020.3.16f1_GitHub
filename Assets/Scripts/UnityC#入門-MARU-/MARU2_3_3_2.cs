using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq.Expressions;

public class MARU2_3_3_2 : MonoBehaviour
{
    //BoxCollider型の変数Aを宣言
    public BoxCollider A;

    //変数Zを宣言
    public MARU2_3_2_1 Z;

    void Start()
    {
        //Debug.Log("Start");

        //MARU2_3_2_1型の変数Zに入っている変数Bのデータを割り当て
        Z.B = "変更しました。";

        //MARU2_3_2_1型の変数Zに入っている関数CCC()を呼び出し
        Z.CCC();
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

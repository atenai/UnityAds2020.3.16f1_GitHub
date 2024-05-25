using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_7_1_2 : MonoBehaviour
{
    //ACTION_TYPEという名前の列挙型を定義
    public enum ACTION_TYPE
    {
        JUMP = 0,
        ATTACK = 1,
        DEFENCE = 2,
    }

    void Start()
    {
        //Debug.Log("Start");

        //ACTION_TYPE型の変数名actionTypeを宣言
        ACTION_TYPE actionType;

        //変数名actionTypeにACTION_TYPEのJUMPを割り当て
        actionType = ACTION_TYPE.JUMP;

        //変数名actionTypeに割り当てされているデータにより処理を切り替え
        switch (actionType)
        {
            case ACTION_TYPE.JUMP:
                //ジャンプ処理
                break;

            case ACTION_TYPE.ATTACK:
                //攻撃処理
                break;

            case ACTION_TYPE.DEFENCE:
                //防御処理
                break;
        }
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

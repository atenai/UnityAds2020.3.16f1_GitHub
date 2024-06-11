using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_1_7_1 : MonoBehaviour
{
    public enum ACTION_TYPE
    {
        JUMP = 0,
        ATTACK = 1,
        DEFENCE = 2,
    }

    public int a;

    void Start()
    {
        //Debug.Log("Start");

        switch (a)
        {
            case 0:
                //ジャンプ処理
                break;

            case 1:
                //攻撃処理
                break;

            case 2:
                //防御処理
                break;
        }
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

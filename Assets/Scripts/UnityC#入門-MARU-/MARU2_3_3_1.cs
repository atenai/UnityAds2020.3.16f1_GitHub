using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq.Expressions;

public class MARU2_3_3_1 : MonoBehaviour
{
    //BoxCollider型の変数Aを宣言
    public BoxCollider A;

    //変数Zを宣言
    public MARU2_3_2_1 Z;

    void Start()
    {
        //Debug.Log("Start");

        //BoxCollider型の変数sizeを変更
        A.size = new Vector3(10.0f, 10.0f, 10.0f);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

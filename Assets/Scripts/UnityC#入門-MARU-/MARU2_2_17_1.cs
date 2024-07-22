using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq.Expressions;

public class MARU2_2_17_1 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        Debug.Log("Testオブジェクトの表示状態 = " + gameObject.activeSelf);
        Debug.Log("Testオブジェクトの位置X = " + transform.position.x);
        Debug.Log("Testオブジェクトの名前 = " + name);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

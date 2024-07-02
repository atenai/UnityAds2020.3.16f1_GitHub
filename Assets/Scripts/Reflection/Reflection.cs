using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

/// <summary>
/// クラス内の全ての変数を取得するクラス
/// </summary>
public class Reflection : MonoBehaviour
{
    public int intValue = 10;
    public float floatValue = 20.5f;
    public string stringValue = "Hello, World!";

    void Start()
    {
        GetFieldsAndValues(this);
    }

    /// <summary>
    /// クラス内の全ての変数を取得する関数
    /// </summary>
    void GetFieldsAndValues(object obj)
    {
        Type type = obj.GetType();
        Debug.Log("型名 : " + type.Name);//今回の場合は、クラスの型
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            object value = field.GetValue(obj);
            Debug.Log("Field Name : " + field.Name);
            Debug.Log("Field Value : " + value);
        }
    }
}

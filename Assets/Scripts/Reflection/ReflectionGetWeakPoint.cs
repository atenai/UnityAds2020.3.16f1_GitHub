using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

/// <summary>
/// クラス内の特定の変数のみを抽出するクラス
/// </summary>
public class ReflectionGetWeakPoint : MonoBehaviour
{
    public List<bool> testList = new List<bool>();

    void Start()
    {
        WeakPointEntity weakPointEntity = new WeakPointEntity();
        GetWeakPoints(weakPointEntity);
    }

    /// <summary>
    /// weak_pointの名前がついた変数のみを抽出する関数
    /// </summary>
    void GetWeakPoints(object obj)
    {
        Type type = obj.GetType();
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            if (field.Name.StartsWith("weak_point"))
            {
                object value = field.GetValue(obj);
                Debug.Log($"Field Name : {field.Name}, Field Value : {value}");
                testList.Add((bool)value);
            }
        }
    }
}

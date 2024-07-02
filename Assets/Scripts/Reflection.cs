using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class Reflection : MonoBehaviour
{
    public int intValue = 10;
    public float floatValue = 20.5f;
    public string stringValue = "Hello, World!";
    public bool isTest = true;

    void Start()
    {
        GetFieldsAndValues(this);
    }

    private void GetFieldsAndValues(object obj)
    {
        Type type = obj.GetType();
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            object value = field.GetValue(obj);
            Debug.Log($"Field Name : {field.Name}, Field Value : {value}");
        }
    }
}

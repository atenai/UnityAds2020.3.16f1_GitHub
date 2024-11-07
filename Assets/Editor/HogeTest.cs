using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Hoge4 : ScriptableObject { }

public class HogeTest
{
    static Hoge4 hoge = null;

    [MenuItem("Kashiwabara/HogeTest/Create")]
    static void Create()
    {
        hoge = ScriptableObject.CreateInstance<Hoge4>();
    }

    [MenuItem("Kashiwabara/HogeTest/Compile")]
    static void Compile()
    {
        EditorUtility.RequestScriptReload();
    }

    [MenuItem("Kashiwabara/HogeTest/Check")]
    static void Check()
    {
        Debug.Log(hoge);
    }
}

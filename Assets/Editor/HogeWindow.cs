#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Hoge3 : ScriptableObject { }

public class HogeWindow : EditorWindow
{
    [MenuItem("Kashiwabara/Hoge")]
    static void Hoge()
    {
        GetWindow<HogeWindow>();
    }

    Hoge3 hoge = null;

    void OnEnable()
    {
        hoge = ScriptableObject.CreateInstance<Hoge3>();
        //hoge.hideFlags = HideFlags.DontSaveInEditor;

        var hoges = Resources.FindObjectsOfTypeAll<Hoge3>();
        Debug.Log(hoges.Length);
    }

    void Update()
    {
        //Debug.Log(hoge);
    }
}
#endif
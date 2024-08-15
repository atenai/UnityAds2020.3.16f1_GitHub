#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

/// <summary>
/// Example24.csと紐づいているクラス
/// </summary> 
[CustomEditor(typeof(Example24))]
public class ExampleInspecto9 : Editor
{
    void OnSceneGUI()
    {
        Tools.current = Tool.None;
        var component = target as Example24;
        Handles.DrawAAPolyLine(component.vertexes);
    }

    void OnEnable()
    {

    }
}
#endif
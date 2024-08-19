#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditorInternal;

/// <summary>
/// Example27.csと紐づいているクラス
/// </summary> 
[CustomEditor(typeof(Example27))]
public class ExampleInspecto12 : Editor
{
    Example27 component;

    void OnEnable()
    {
        //ここは様式美
        Tools.current = Tool.None;
        component = target as Example27;
        //ここは様式美
    }

    void OnSceneGUI()
    {
        Handles.BeginGUI();

        GUILayout.Button("Button", GUILayout.Width(50));

        Handles.EndGUI();
    }
}
#endif
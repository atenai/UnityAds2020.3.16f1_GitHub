#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditorInternal;

/// <summary>
/// Example28.csと紐づいているクラス
/// </summary> 
[CustomEditor(typeof(Example28))]
public class ExampleInspecto13 : Editor
{
    Example28 component;

    void OnEnable()
    {
        //ここは様式美
        Tools.current = Tool.None;
        component = target as Example28;
        //ここは様式美
    }

    void OnSceneGUI()
    {
        using (new HandleGUIScope())
        {
            GUILayout.Button("Button", GUILayout.Width(50));
        }
    }
}
#endif
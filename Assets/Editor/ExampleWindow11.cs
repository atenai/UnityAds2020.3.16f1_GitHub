using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;


public class ExampleWindow11 : EditorWindow
{
    [MenuItem("Kashiwabara/Example11")]
    static void Open()
    {
        GetWindow<ExampleWindow11>();
    }

    void OnGUI()
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Button("Button1");
            GUILayout.Button("Button2");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExampleWindow5 : EditorWindow
{
    [MenuItem("Kashiwabara/Example5")]
    static void Open()
    {
        GetWindow<ExampleWindow5>();
    }

    void OnGUI()
    {
        Display();

        EditorGUILayout.Space();

        GUI.enabled = false;

        Display();

        GUI.enabled = true;
    }

    void Display()
    {
        EditorGUILayout.ToggleLeft("Toggle", false);
        EditorGUILayout.IntSlider(0, 10, 0);
        GUILayout.Button("Button");
    }
}

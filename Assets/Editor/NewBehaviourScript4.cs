using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NewBehaviourScript4 : EditorWindow
{
    [MenuItem("Kashiwabara/Example4")]
    static void Open()
    {
        GetWindow<NewBehaviourScript4>();
    }

    void OnGUI()
    {
        Display();

        EditorGUILayout.Space();

        EditorGUI.BeginDisabledGroup(true);

        Display();

        EditorGUI.EndDisabledGroup();
    }

    void Display()
    {
        EditorGUILayout.ToggleLeft("Toggle", false);
        EditorGUILayout.IntSlider(0, 10, 0);
        GUILayout.Button("Button");
    }
}
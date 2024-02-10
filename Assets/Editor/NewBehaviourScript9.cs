using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class NewBehaviourScript9 : EditorWindow
{
    [MenuItem("Kashiwabara/Example9")]
    static void Open()
    {
        GetWindow<NewBehaviourScript9>();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Parent");

        EditorGUI.indentLevel++;

        EditorGUILayout.LabelField("Child");

        EditorGUILayout.LabelField("Child");

        EditorGUI.indentLevel--;

        EditorGUILayout.LabelField("Parent");

        EditorGUI.indentLevel++;

        EditorGUILayout.LabelField("Child");
    }
}

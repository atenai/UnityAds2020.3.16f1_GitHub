using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class NewBehaviourScript8 : EditorWindow
{
    [MenuItem("Kashiwabara/Example8")]
    static void Open()
    {
        GetWindow<NewBehaviourScript8>();
    }

    float[] numbers = new float[] { 0, 1, 2 };

    GUIContent[] contents = new GUIContent[]
    {
        new GUIContent("X"),
        new GUIContent("Y"),
        new GUIContent("Z")
    };

    void OnGUI()
    {
        EditorGUI.MultiFloatField(new Rect(30, 30, 200, EditorGUIUtility.singleLineHeight), new GUIContent("Label"), contents, numbers);
    }
}

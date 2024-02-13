using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class NewBehaviourScript10 : EditorWindow
{
    [MenuItem("Kashiwabara/Example10")]
    static void Open()
    {
        GetWindow<NewBehaviourScript10>();
    }

    float angle = 0.0f;

    void OnGUI()
    {
        angle = EditorGUILayout.Knob(Vector2.one * 64, angle, 0, 360, "度", Color.gray, Color.red, true);
    }
}

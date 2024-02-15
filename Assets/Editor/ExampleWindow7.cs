using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class ExampleWindow7 : EditorWindow
{
    [MenuItem("Kashiwabara/Example7")]
    static void Open()
    {
        GetWindow<ExampleWindow7>();
    }

    void OnGUI()
    {
        EditorGUILayout.ObjectField(null, typeof(object), false);

        EditorGUILayout.ObjectField(null, typeof(Material), false);

        EditorGUILayout.ObjectField(null, typeof(AudioClip), false);

        var options = new[] { GUILayout.Width(64), GUILayout.Height(64) };

        EditorGUILayout.ObjectField(null, typeof(Texture), false, options);

        EditorGUILayout.ObjectField(null, typeof(Sprite), false, options);
    }
}

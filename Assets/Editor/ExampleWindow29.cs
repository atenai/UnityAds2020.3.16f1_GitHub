using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class ExampleWindow29 : EditorWindow
{
    [MenuItem("Kashiwabara/Example29")]
    static void SaveEditorWindow()
    {
        var window = GetWindow<ExampleWindow29>();

        var icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Textures/Logo.png");

        window.titleContent = new GUIContent("Hoge", icon);
    }
}

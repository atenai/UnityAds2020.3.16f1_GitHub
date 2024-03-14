using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class ExampleWindow31 : EditorWindow
{
    [MenuItem("Kashiwabara/Example31")]
    static void SaveEditorWindow()
    {
        AssetDatabase.CreateAsset(CreateInstance<ExampleWindow31>(), "Assets/Example.asset");
        AssetDatabase.Refresh();
    }

    [SerializeField]
    string text;

    [SerializeField]
    bool boolean;
}

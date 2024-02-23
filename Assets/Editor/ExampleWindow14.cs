using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

/// <summary>
/// 単数のみ許可するEditorWindowの機能を1つにまとめたAPI
/// </summary>
public class ExampleWindow14 : EditorWindow
{
    [MenuItem("Kashiwabara/Example14")]
    static void Open()
    {
        GetWindow<ExampleWindow14>();
    }


    void OnGUI()
    {

    }
}

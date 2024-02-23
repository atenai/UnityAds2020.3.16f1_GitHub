using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

/// <summary>
/// 単数のみ許可するEditorWindow
/// </summary>
public class ExampleWindow13 : EditorWindow
{
    static ExampleWindow13 exampleWindow;

    [MenuItem("Kashiwabara/Example13")]
    static void Open()
    {
        if (exampleWindow == null)
        {
            exampleWindow = CreateInstance<ExampleWindow13>();
        }
        exampleWindow.Show();
    }


    void OnGUI()
    {

    }
}

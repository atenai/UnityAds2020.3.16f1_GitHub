using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

/// <summary>
/// タブウィンドウではなく、通常のウィンドウとして表示するEditorWindow
/// </summary>
public class ExampleWindow16 : EditorWindow
{
    static ExampleWindow16 exampleWindow;

    [MenuItem("Kashiwabara/Example16")]
    static void Open()
    {
        if (exampleWindow == null)
        {
            exampleWindow = CreateInstance<ExampleWindow16>();
        }
        exampleWindow.ShowUtility();
    }


    void OnGUI()
    {

    }
}

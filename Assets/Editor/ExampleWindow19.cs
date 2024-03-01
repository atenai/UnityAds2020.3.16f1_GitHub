using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

/// <summary>
/// タイトルと閉じるボタンがないウィンドウとして表示するEditorWindow
/// </summary>
public class ExampleWindow19 : EditorWindow
{
    static ExampleWindow19 exampleWindow;

    [MenuItem("Kashiwabara/Example19")]
    static void Open()
    {
        if (exampleWindow == null)
        {
            exampleWindow = CreateInstance<ExampleWindow19>();
        }

        var buttonRect = new Rect(100, 100, 300, 100);
        var windowSize = new Vector2(300, 100);
        exampleWindow.ShowAsDropDown(buttonRect, windowSize);
    }

    void OnGUI()
    {

    }
}

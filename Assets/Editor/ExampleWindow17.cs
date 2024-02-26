using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

/// <summary>
/// 通常のウィンドウかつタイトルと閉じるボタンがないウィンドウとして表示するEditorWindow
/// </summary>
public class ExampleWindow17 : EditorWindow
{
    static ExampleWindow17 exampleWindow;

    [MenuItem("Kashiwabara/Example17")]
    static void Open()
    {
        if (exampleWindow == null)
        {
            exampleWindow = CreateInstance<ExampleWindow17>();
        }
        exampleWindow.ShowPopup();
    }


    void OnGUI()
    {
        //エスケープを押した時に閉じる
        if (Event.current.keyCode == KeyCode.Escape)
        {
            exampleWindow.Close();
        }
    }
}

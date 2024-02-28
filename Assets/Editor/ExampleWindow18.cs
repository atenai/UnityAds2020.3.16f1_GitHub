using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

/// <summary>
/// ポップアップウィンドウを表示するEditorWindow
/// </summary>
public class ExampleWindow18 : EditorWindow
{
    [MenuItem("Kashiwabara/Example18")]
    static void Open()
    {
        GetWindow<ExampleWindow18>();
    }

    //インスタンス化
    ExamplePopupContent popupContent = new ExamplePopupContent();

    void OnGUI()
    {
        if (GUILayout.Button("PopupContent", GUILayout.Width(128)))
        {
            var activatorRect = GUILayoutUtility.GetLastRect();
            //Popupを表示する
            PopupWindow.Show(activatorRect, popupContent);
        }
    }
}
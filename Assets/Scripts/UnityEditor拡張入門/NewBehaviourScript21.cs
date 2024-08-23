#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/// <summary>
/// エディタウィンドウを作る為の金型
/// </summary>
public class NewBehaviourScript21 : EditorWindow
{
    [MenuItem("Kashiwabara/NewBehaviourScript21")]
    static void Open()
    {
        GetWindow<NewBehaviourScript21>();
    }

    //OnGUI()はEditorWindowだとエディタウィンドウに表示され、MonoBehaviourだとゲーム画面に表示される
    void OnGUI()
    {
        GUILayoutOption[] options = new[]
        {
            GUILayout.Width(96),
            GUILayout.Height(96)
        };
        EditorGUILayout.ObjectField(null, typeof(Texture2D), false, options);
        EditorGUILayout.Space();

        //GUIStyleはスタイル名で指定することも可能
        GUILayout.Label("ラベル", "box");
        EditorGUILayout.ObjectField(null, typeof(Sprite), false, options);
    }
}
#endif
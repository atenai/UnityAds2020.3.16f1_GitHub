using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NewBehaviourScript3 : EditorWindow
{
    [MenuItem("Kashiwabara/Example3")]
    static void Open()
    {
        GetWindow<NewBehaviourScript3>();
    }

    bool toggleValue;

    Stack<bool> stack = new Stack<bool>();

    void OnGUI()
    {
        EditorGUILayout.LabelField("Example Label");

        EditorGUI.BeginChangeCheck();

        //toggleをマウスでクリックして値を変更する
        toggleValue = EditorGUILayout.ToggleLeft("Toggle", toggleValue);

        //toggleValueの値が変更されるたびにtrueになる
        if (EditorGUI.EndChangeCheck())
        {
            if (toggleValue == true)
            {
                Debug.Log("toggleValueがtrueになった瞬間呼び出される");
            }
        }

        //BeginChangeCheckの役割
        //{
        //先頭に値をpush
        stack.Push(GUI.changed);
        GUI.changed = false;
        //}

        toggleValue = EditorGUILayout.ToggleLeft("Toggle", toggleValue);

        //EndChangeCheckの役割
        //{
        bool changed = GUI.changed;

        //どちらかがtrueであれば以降は全て変更されているものとする
        // |= は論理和らしい、左辺値と右辺値の両方または片方がtrueならtrueを、両方ともfalseならfalseを返す。
        GUI.changed |= stack.Pop();
        //}

        if (changed == true)
        {
            Debug.Log("toggleValueがtrueになった瞬間呼び出される");
        }
    }
}

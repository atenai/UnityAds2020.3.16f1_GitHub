using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExampleWindow3 : EditorWindow
{
    [MenuItem("Kashiwabara/Example3")]
    static void Open()
    {
        GetWindow<ExampleWindow3>();
    }

    bool toggleValue;

    Stack<bool> stack = new Stack<bool>();

    void OnGUI()
    {
        ///(3)
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
        ///(3)
    }
}

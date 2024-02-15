using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExampleWindow2 : EditorWindow
{
    [MenuItem("Kashiwabara/Example2")]
    static void Open()
    {
        GetWindow<ExampleWindow2>();
    }

    bool toggleValue;

    void OnGUI()
    {
        ///(2)
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
        ///(2) 
    }
}

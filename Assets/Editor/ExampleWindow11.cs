using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;


public class ExampleWindow11 : EditorWindow
{
    [MenuItem("Kashiwabara/Example11")]
    static void Open()
    {
        GetWindow<ExampleWindow11>();
    }

    bool on;

    void OnGUI()
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Button("Button1");
            GUILayout.Button("Button2");
        }

        using (new BackgroundColorScope(Color.green))
        {
            //緑色のボタン
            GUILayout.Button("Button3");
        }

        using (new BackgroundColorScope(Color.yellow))
        {
            //黄色のボタン
            GUILayout.Button("Button4");
        }

        //GUIStyleは文字列で指定することも出来る
        on = GUILayout.Toggle(on, on ? "on" : "off", "button");
    }
}

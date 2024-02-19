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

    bool one, two, three;

    int selected1;
    int selected2;
    int selected3;

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

        using (new EditorGUILayout.HorizontalScope())
        {
            one = GUILayout.Toggle(one, "1", EditorStyles.miniButtonLeft);
            two = GUILayout.Toggle(two, "2", EditorStyles.miniButtonMid);
            three = GUILayout.Toggle(three, "3", EditorStyles.miniButtonRight);
        }

        selected1 = GUILayout.Toolbar(selected1, new string[] { "1", "2", "3" });
        selected2 = GUILayout.Toolbar(selected2, new string[] { "1", "2", "3" }, EditorStyles.toolbarButton);

        selected3 = GUILayout.SelectionGrid(selected3, new string[] { "1", "2", "3" }, 1, "PreferencesKeysElement");
    }
}

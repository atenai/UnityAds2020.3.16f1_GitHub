using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExampleWindow : EditorWindow
{
    int intervalTime = 60;

    const string AUTO_SAVE_INTERVAL_TIME = "AutoSaveinterval time (sec)";
    const string SIZE_WIDTH_KEY = "ExampleWindow size width";
    const string SIZE_HEIGHT_KEY = "ExampleWindow size height";

    [MenuItem("Window/Example")]//Unityエディタの上にあるWindowメニューに追加される
    static void Open()
    {
        GetWindow<ExampleWindow>();
    }

    void OnEnable()
    {
        intervalTime = EditorPrefs.GetInt(AUTO_SAVE_INTERVAL_TIME, 60);//ロード
        var width = EditorPrefs.GetFloat(SIZE_WIDTH_KEY, 600);
        var height = EditorPrefs.GetFloat(SIZE_HEIGHT_KEY, 400);
        position = new Rect(position.x, position.y, width, height);
    }

    void OnDisable()
    {
        EditorPrefs.SetFloat(SIZE_WIDTH_KEY, position.width);
        EditorPrefs.SetFloat(SIZE_HEIGHT_KEY, position.height);
    }

    void OnGUI()
    {
        EditorGUI.BeginChangeCheck();//Inspectorで要素が変更されたかどうかを確認する

        //シーン自動保存間隔（秒）
        intervalTime = EditorGUILayout.IntSlider("間隔（秒）", intervalTime, 1, 3600);

        if (EditorGUI.EndChangeCheck() == true)//Inspectorで要素が変更された場合は、中身を実行する
        {
            EditorPrefs.SetInt(AUTO_SAVE_INTERVAL_TIME, intervalTime);//セーブ
        }
    }
}

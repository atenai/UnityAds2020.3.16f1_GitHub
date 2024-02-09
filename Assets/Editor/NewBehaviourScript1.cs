using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NewBehaviourScript1 : EditorWindow
{
    [MenuItem("Kashiwabara/Example1")]//上のウィンドウメニュー欄に追加される
    static void Open()
    {
        //指定したクラス（このクラス）がウィンドウメニューの内容になる
        GetWindow<NewBehaviourScript1>();
    }

    void OnGUI()
    {
        ///(1)
        //ラベル名を追加
        EditorGUILayout.LabelField("Example Label");
        ///(1)
    }
}

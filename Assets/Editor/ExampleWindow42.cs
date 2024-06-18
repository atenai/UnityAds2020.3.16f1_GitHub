using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class ExampleWindow42 : EditorWindow
{
    //ウィンドウ作成
    [MenuItem("Kashiwabara/Example42")]
    static void Open()
    {
        GetWindow<ExampleWindow42>();
    }

    GameObject go;

    int group1 = 0;
    int group2 = 0;
    int group3 = 0;

    void OnEnable()
    {
        go = GameObject.Find("New Game Object");
    }

    void OnGUI()
    {
        //マウスをクリックしたら
        if (Event.current.type == EventType.MouseDown)
        {
            //現在のグループインデックスを保持
            group1 = Undo.GetCurrentGroup();

            //1つめ追加
            Undo.AddComponent<Rigidbody>(go);

            //インクリメント
            Undo.IncrementCurrentGroup();

            //現在のグループインデックスを保持
            group2 = Undo.GetCurrentGroup();

            //2つめ追加
            Undo.AddComponent<BoxCollider>(go);

            //インクリメント
            Undo.IncrementCurrentGroup();

            //現在のグループインデックスを保持
            group3 = Undo.GetCurrentGroup();

            //3つめ追加
            Undo.AddComponent<ConstantForce>(go);
        }

        if (Event.current.type == EventType.MouseUp)
        {
            //group2まで戻る（1つ目のみが追加されている状態）

            Undo.RevertAllDownToGroup(group2);
            //コンポーネントのGUIが変更されたことによる
            //描画エラーを回避するためにExitGUIを呼び出す

            EditorGUIUtility.ExitGUI();
        }
    }
}

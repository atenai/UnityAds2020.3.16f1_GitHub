#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor;
using UnityEngine;


/// <summary>
/// エディタウィンドウを作る為の金型
/// </summary>
public class NewBehaviourScript22 : EditorWindow
{
    private Sprite sprite;
    private int id;
    private Rect buttonRect = new Rect(10, 10, 100, 20);

    [MenuItem("Kashiwabara/NewBehaviourScript22")]
    static void Open()
    {
        GetWindow<NewBehaviourScript22>();
    }

    //OnGUI()はEditorWindowだとエディタウィンドウに表示され、MonoBehaviourだとゲーム画面に表示される
    void OnGUI()
    {
        id = GUIUtility.GetControlID(FocusType.Passive);

        //コマンド名がObjectSelectorUpdatedでオブジェクトピッカーが
        //現在のコントロール中のGUIによるものであった場合
        if (Event.current.commandName == "ObjectSelectorUpdated" && id == EditorGUIUtility.GetObjectPickerControlID())
        {
            //オブジェクトピッカーで選択中のオブジェクトを取得
            sprite = EditorGUIUtility.GetObjectPickerObject() as Sprite;
            //GUIを再描画
            HandleUtility.Repaint();
        }

        if (GUI.Button(buttonRect, "select", EditorStyles.objectFieldThumb.name + "Overlay2"))
        {
            //現在のコントロールIDに対するオブジェクトピッカーを表示する
            EditorGUIUtility.ShowObjectPicker<Sprite>(sprite, false, "", id);
            //オブジェクトピッカーを表示するイベントを発行したのでイベントのUseを実行する
            Event.current.Use();
        }
    }
}
#endif
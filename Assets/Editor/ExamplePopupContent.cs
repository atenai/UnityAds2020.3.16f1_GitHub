using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// ポップアップウィンドウの中身
/// </summary> 
public class ExamplePopupContent : PopupWindowContent
{
    public override void OnGUI(Rect rect)
    {
        EditorGUILayout.LabelField("Label");
    }

    public override void OnOpen()
    {
        Debug.Log("表示するときに呼び出される");
    }

    public override void OnClose()
    {
        Debug.Log("閉じるときに呼び出される");
    }

    public override Vector2 GetWindowSize()
    {
        //Popupのサイズ
        return new Vector2(300, 100);
    }
}

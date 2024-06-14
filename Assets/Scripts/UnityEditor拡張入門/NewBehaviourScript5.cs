using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// ヒエラルキーで選択したゲームオブジェクトをMain Cameraの子オブジェクトにする
/// </summary>
public class NewBehaviourScript5
{
    [MenuItem("UndoExample/Undo/SetTransformParent")]//上のメニューに項目の追加をする
    static void SetTransformParent()
    {
        //Main Cameraのトランスフォームを取得
        Transform root = GameObject.Find("Main Camera").transform;
        Debug.Log(root);

        //ヒエラルキーで選択したゲームオブジェクトのトランスフォームを取得
        Transform transform = Selection.activeTransform;
        Debug.Log(transform);

        Undo.SetTransformParent(transform, root, "Main Cameraオブジェクトの子要素にする");
    }
}

#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// ヒエラルキーで選択したゲームオブジェクトを破棄する
/// </summary>
public class NewBehaviourScript6
{
    [MenuItem("UndoExample/Undo/DestroyObjectImmediate")]//上のメニューに項目の追加をする
    static void DestroyObjectImmediate()
    {
        //ヒエラルキーで選択したゲームオブジェクトを取得
        GameObject go = Selection.activeGameObject;

        //選択したGameObjectを破棄。Undoで破棄以前の状態に戻る
        Undo.DestroyObjectImmediate(go);
    }
}
#endif
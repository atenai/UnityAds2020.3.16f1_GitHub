#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NewBehaviourScript2
{
    [MenuItem("UndoExample/Undo/RecordObject")]//上のメニューに項目の追加をする
    static void RecordObject()
    {
        //選択状態のTransformを取得する
        Transform transform = Selection.activeTransform;

        //これから変更するプロパティーのオブジェクトの指定とUndo名
        Undo.RecordObject(transform, "positionをVector3(0,0,0)に変更");
        transform.position = new Vector3(0, 0, 0);
    }
}
#endif
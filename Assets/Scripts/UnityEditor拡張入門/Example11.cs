#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Example11
{
    [MenuItem("UndoExample/Example11/Random Rotate")]//上のメニューに項目の追加をする
    static void RandomRotate()//必ずstatic型
    {
        var transform = Selection.activeTransform;

        if (transform)
        {
            Undo.willFlushUndoRecord += () => Debug.Log("flush");

            Undo.postprocessModifications += (modifications) =>
            {
                Debug.Log("modifications");
                return modifications;
            };

            Undo.RecordObject(transform, "Rotate " + transform.name);//Undo.RecordObject関数を実行すると「変更前」のTransformの値をUndoスタックに保存できる
            Debug.Log("recorded");

            transform.rotation = Random.rotation;
            Debug.Log("changed");
        }
    }
}
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Example10
{
    [MenuItem("Example10/Random Rotate")]//上のメニューに項目の追加をする
    static void RandomRotate()//必ずstatic型
    {
        var transform = Selection.activeTransform;

        if (transform)
        {
            Undo.RecordObject(transform, "Rotate " + transform.name);//Undo.RecordObject関数を実行すると「変更前」のTransformの値をUndoスタックに保存できる

            transform.rotation = Random.rotation;
        }
    }
}

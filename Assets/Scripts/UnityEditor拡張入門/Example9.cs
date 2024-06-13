using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Example9
{
    [MenuItem("UndoExample/Example9/Random Rotate")]//上のメニューに項目の追加をする
    static void RandomRotate()//必ずstatic型
    {
        var transform = Selection.activeTransform;

        if (transform)
        {
            transform.rotation = Random.rotation;
        }
    }
}

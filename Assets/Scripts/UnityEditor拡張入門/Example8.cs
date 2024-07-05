#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Example8
{
    [MenuItem("UndoExample/Example8/Create Cube")]//上のメニューに項目の追加をする
    static void CreateCube()//必ずstatic型
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);//キューブを生成
        Undo.RegisterCreatedObjectUndo(cube, "Create Cube");//キューブを削除する（元に戻す）
    }
}
#endif
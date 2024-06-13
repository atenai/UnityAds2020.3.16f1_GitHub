using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Example7
{
    [MenuItem("UndoExample/Example7/Create Cube")]//上のメニューに項目の追加をする
    static void CreateCube()//必ずstatic型
    {
        GameObject.CreatePrimitive(PrimitiveType.Cube);//キューブを生成
    }
}

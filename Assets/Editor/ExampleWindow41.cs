using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class ExampleWindow41
{
    //Transformにメニューを追加
    [MenuItem("CONTEXT/Transform/Example41_1")]
    static void Example1(MenuCommand menuCommand)
    {
        //実行したTransformの情報が取得できる
        Debug.Log(menuCommand.context);
    }
}

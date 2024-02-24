using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

/// <summary>
/// 単数のみ許可するEditorWindowの機能を1つにまとめたAPI
/// </summary>
public class ExampleWindow15 : EditorWindow
{
    [MenuItem("Kashiwabara/Example15")]
    static void Open()
    {
        //引数のtypeof(SceneView)でSceneビューと同じタブの位置に生成される
        GetWindow<ExampleWindow15>(typeof(SceneView));
    }


    void OnGUI()
    {

    }
}

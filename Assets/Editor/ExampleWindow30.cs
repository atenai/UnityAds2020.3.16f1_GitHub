using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class ExampleWindow30 : EditorWindow
{
    [MenuItem("Kashiwabara/Example30")]
    static void Open()
    {
        //すべてのシーンビューを取得する
        var sceneViews = Resources.FindObjectsOfTypeAll<SceneView>();
    }
}

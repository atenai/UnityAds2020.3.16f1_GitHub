#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
using UnityEditor.Callbacks;
using System.IO;
using UnityEditor.iOS.Xcode;
using UnityEditor.SceneManagement;

public class NewBehaviourScript9
{
    // [PostProcessScene]
    // static void OnPostProcessScene()
    // {
    //     //現在のマルチシーン情報を取得
    //     foreach (var sceneSetup in EditorSceneManager.GetSceneManagerSetup())
    //     {
    //         var scene = EditorSceneManager.GetSceneByPath(sceneSetup.path);
    //         var go = new GameObject("OnPostProcessScene: " + scene.name);

    //         EditorSceneManager.MoveGameObjectToScene(go, scene);
    //     }
    // }
}
#endif
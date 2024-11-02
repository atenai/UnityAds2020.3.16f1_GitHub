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
using System.Linq;
using UnityEditor.SearchService;
using UnityEditor.VersionControl;

/// <summary>
/// 
/// </summary>
public class ExampleWindow49 : EditorWindow
{
    [MenuItem("Kashiwabara/Create New GameObject")]
    static void CreateNewGameObject()
    {
        //ヒエラルキーにゲームオブジェクトを生成する
        new GameObject("New GameObject");
    }

    [MenuItem("Kashiwabara/Create New GameObject2")]
    static void CreateNewGameObject2()
    {
        //ヒエラルキーにゲームオブジェクトを生成する
        var go = new GameObject("New GameObject2");

        //ヒエラルキーに表示しない
        go.hideFlags = HideFlags.HideInHierarchy;
    }

    [MenuItem("Kashiwabara/Find New GameObject2")]
    static void FindNewGameObject2()
    {
        var go = GameObject.Find("New GameObject2");

        Debug.Log(go);
    }

    [MenuItem("Kashiwabara/Create New GameObject3")]
    static void CreateNewGameObject3()
    {
        //ヒエラルキーにCubeゲームオブジェクトを生成する
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //名前を変更
        go.name = "New GameObject3";
        //ヒエラルキーに表示しない
        go.hideFlags = HideFlags.HideInHierarchy;
    }

    [MenuItem("Kashiwabara/Create New GameObject4")]
    static void CreateNewGameObject4()
    {
        //ヒエラルキーにCubeゲームオブジェクトを生成する
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //名前を変更
        go.name = "New GameObject4";
        //ヒエラルキーに表示しない
        go.hideFlags = HideFlags.HideInHierarchy;
        Selection.activeGameObject = go;
    }

    [MenuItem("Kashiwabara/Create SubAssets")]
    static void HideReference()
    {
        var path = "Assets/1st.anim";
        var first = new AnimationClip { name = "1st" };

        var second = new AnimationClip
        {
            name = "2nd",
            hideFlags = HideFlags.HideInHierarchy
        };

        var third = new AnimationClip
        {
            name = "3rd",
            hideFlags = HideFlags.HideInHierarchy
        };

        //サブアセット化
        AssetDatabase.AddObjectToAsset(second, first);
        AssetDatabase.AddObjectToAsset(third, first);
        AssetDatabase.ImportAsset(path);
    }
}
#endif
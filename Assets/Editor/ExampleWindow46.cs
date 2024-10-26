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

public class ExampleWindow46 : EditorWindow
{
    [MenuItem("Kashiwabara/Example46")]
    static void Open()
    {
        //まだアセットとして存在しないオブジェクトを作成
        var clip = new AnimationClip();

        //アセットとして保存
        //AssetDatabaseで扱うパスはUnityプロジェクトから相対パスで指定できる
        AssetDatabase.CreateAsset(clip, "Assets/Animation/New AnimationClip.anim");
    }
}
#endif
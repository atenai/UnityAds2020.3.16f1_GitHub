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

/// <summary>
/// テキストを作成するクラス
/// </summary>
public class ExampleWindow48 : EditorWindow
{
    [MenuItem("Kashiwabara/Example48_1")]
    static void CreateTextAsset1()
    {
        //生成する位置（パス）と名前
        var path = "Assets/New TextAsset1.txt";
        //生成したテキストの内容
        var text = "text1";
        File.WriteAllText(path, text);

        //リフレッシュすることにより全体のアセットをインポートする
        AssetDatabase.Refresh();
    }

    [MenuItem("Kashiwabara/Example48_2")]
    static void CreateTextAsset2()
    {
        //生成する位置（パス）と名前
        var path = "Assets/New TextAsset2.txt";
        //生成したテキストの内容
        var text = "text2";
        File.WriteAllText(path, text);

        //パスを指定して特定のアセットをインポートする
        AssetDatabase.ImportAsset(path);
    }
}
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;


#if UNITY_EDITOR
using UnityEditor;
#endif


public class ResouceLoad : MonoBehaviour
{
    [InitializeOnLoadMethod]//UnityEditor起動直後のみ処理を実行する
    static void GetBultinAssetNames()
    {
        //↓アセットバンドルを全て取得してアセットがあるか？を確認するコード↓
        BindingFlags flags = BindingFlags.Static | BindingFlags.NonPublic;
        MethodInfo info = typeof(EditorGUIUtility).GetMethod("GetEditorAssetBundle", flags);
        AssetBundle bundle = info.Invoke(null, new object[0]) as AssetBundle;

        //bundle.GetAllAssetNames()は全てのアセットのパスを確認する
        foreach (var n in bundle.GetAllAssetNames())
        {
            //Debug.Log(n);
        }
        //↑アセットバンドルを全て取得してアセットがあるか？を確認するコード↑
    }

    void Start()
    {
        //TestIconLoad();
    }

    void Update()
    {

    }

    void TestIconLoad()
    {
        //EditorGUIUtility.Load()はアセットをロードする
        //EditorGUIUtility.Load()は、「"Assets/Editor Default Resources/" + path」にアセットがあるかを最初に確認しに行く
        //↑にアセットがなければ、アセットバンドルからアセットをロードする
        UnityEngine.Texture tex = EditorGUIUtility.Load("Icon.png") as Texture;
        Debug.Log(tex);
    }
}

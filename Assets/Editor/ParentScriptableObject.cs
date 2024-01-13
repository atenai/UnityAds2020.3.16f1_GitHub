using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ParentScriptableObject : ScriptableObject
{
    const string PATH = "Assets/Editor/NewParentScriptableObject.asset";

    [SerializeField]
    ChildScriptableObject child;

    [MenuItem("Assets/CreateScriptableObject")]
    static void CreateScriptableObject()
    {
        //親をインスタンス化
        var parent = ScriptableObject.CreateInstance<ParentScriptableObject>();

        //子をインスタンス化
        parent.child = ScriptableObject.CreateInstance<ChildScriptableObject>();

        //親のアセットとして保存
        AssetDatabase.CreateAsset(parent, PATH);

        //インポート処理を走らせて最新の状態にする
        AssetDatabase.ImportAsset(PATH);
    }
}

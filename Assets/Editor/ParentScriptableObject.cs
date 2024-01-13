using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]//CreateAssetMenu属性を使用することでメニューに「Assets > Create > ParentScriptableObject」が表示される、ParentScriptableObjectを押すとアセットが作成される
public class ParentScriptableObject : ScriptableObject
{
    const string PATH = "Assets/Editor/NewParentScriptableObject.asset";

    [SerializeField]
    ChildScriptableObject child;

    [MenuItem("Kashiwabara/CreateScriptableObject")]
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

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

        //サブアセットとなるchildを非表示にする
        parent.child.hideFlags = HideFlags.HideInHierarchy;

        //親にchildオブジェクトを追加
        AssetDatabase.AddObjectToAsset(parent.child, PATH);

        //親のアセットとして保存
        AssetDatabase.CreateAsset(parent, PATH);

        //インポート処理を走らせて最新の状態にする
        AssetDatabase.ImportAsset(PATH);
    }

    [MenuItem("Kashiwabara/Set to HideFlags.None")]
    static void SetHideFlags()
    {
        //AnimatorControllerを選択した状態でメニューを実行
        var path = AssetDatabase.GetAssetPath(Selection.activeObject);

        //サブアセット含めすべて取得
        foreach (var item in AssetDatabase.LoadAllAssetsAtPath(path))
        {
            //フラグを全てNoneにして非表示設定を解除
            item.hideFlags = HideFlags.None;
        }

        //再インポートして最新にする
        AssetDatabase.ImportAsset(path);
    }

    [MenuItem("Kashiwabara/RemoveChildScriptableObject")]
    static void Remove()
    {
        var parent = AssetDatabase.LoadAssetAtPath<ParentScriptableObject>(PATH);

        //アセットのCarentScriptableObjectを破棄
        Object.DestroyImmediate(parent.child, true);

        //破棄したらMissing状態になるのでnullを代入
        parent.child = null;
    }
}

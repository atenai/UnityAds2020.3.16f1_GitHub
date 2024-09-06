#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Overwriter : AssetPostprocessor
{
    //hoge.pngがある状態でhoge.pngをインポート
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromPath)
    {
        if (Event.current.type != EventType.DragPerform)
        {
            return;
        }

        //リネーム後のhoge1.pngでインポートされていることを確認
        var hoge1 = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/hoge1.png");
        Debug.Log(hoge1);

        //hoge.pngのパスが格納されていることを確認
        foreach (var path in DragAndDrop.paths)
        {
            Debug.Log(path);
        }

        foreach (var assetPath in importedAssets)
        {
            //インポートされたアセットを監視
        }
    }
}
#endif
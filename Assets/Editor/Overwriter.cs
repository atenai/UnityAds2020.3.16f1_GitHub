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

        //スクリプトの編集によるインポート時はEvent.currentはnullなので、nullチェックをする
        if (Event.current == null || Event.current.type != EventType.DragPerform)
        {
            return;
        }

        // var result = EditorUtility.DisplayDialogComplex(asset.originalAssetPath, overwriteMessage, "置き換える", "両方とも残す", "中止");

        // if (result == 0)
        // {
        //     asset.Overwrite();
        // }
        // else if (result == 2)
        // {
        //     asset.Delete();
        // }

        foreach (var assetPath in importedAssets)
        {
            //インポートされたアセットを監視
        }
    }
}
#endif
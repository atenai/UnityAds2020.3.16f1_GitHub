#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Overwriter : AssetPostprocessor
{
    const string message = "\"{0}.{1}\"という名前のアセットがすでにこの場所にあります。アセットを置き換えますか？";

    //hoge.pngがある状態でhoge.pngをインポート
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromPath)
    {
        //スクリプトの編集によるインポート時はEvent.currentはnullなので、nullチェックをする
        if (Event.current == null || Event.current.type != EventType.DragPerform)
        {
            return;
        }

        foreach (var assetPath in importedAssets)
        {
            //インポートされたアセットを監視
            var asset = new OverwriteAsset(assetPath);

            if (asset.exists)
            {
                var overwriteMessage = string.Format(message, asset.filename, asset.extension);
                var result = EditorUtility.DisplayDialogComplex(asset.originalAssetPath, overwriteMessage, "置き換える", "両方とも残す", "中止");

                if (result == 0)
                {
                    asset.Overwrite();
                }
                else if (result == 2)
                {
                    asset.Delete();
                }
            }
        }
    }
}
#endif
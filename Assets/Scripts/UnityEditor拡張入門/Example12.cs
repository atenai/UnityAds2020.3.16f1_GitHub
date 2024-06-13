using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Example12
{
    [MenuItem("UndoExample/Example12/Change PlayerInfo")]//上のメニューに項目の追加をする
    static void ChangePlayerinfo()//必ずstatic型
    {
        var player = Selection.activeGameObject.GetComponent<EditorExtensions.Player>();

        if (player)
        {
            Undo.RecordObject(player, "Change PlayerInfo");//Undo.RecordObject関数を実行すると「変更前」の値をUndoスタックに保存できる
            player.info = new PlayerInfo
            {
                name = "New PlayerName",
                hp = Random.Range(0, 10),
            };
        }
    }
}

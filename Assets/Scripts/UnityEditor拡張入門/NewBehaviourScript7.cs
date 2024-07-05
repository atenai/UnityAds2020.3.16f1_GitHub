#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class NewBehaviourScript7
{
    //必ず宝くじが当選するメソッド
    [MenuItem("UndoExample/Undo/RevertAllInCurrentGroup")]//上のメニューに項目の追加をする
    static void RevertAllInCurrentGroup()
    {
        GameObject ticket = new GameObject("Ticket");

        Undo.RegisterCreatedObjectUndo(ticket, "宝くじ買いました");

        //チケットの番号はこれです
        int number = ticket.GetInstanceID();

        //当選番号はこれです
        int winningNumber = 1234;

        if (ticket.GetInstanceID() != winningNumber)
        {
            //当たりませんでした
            //宝くじを買ったのをなかったことにします

            Undo.RevertAllInCurrentGroup();
        }
    }
}
#endif
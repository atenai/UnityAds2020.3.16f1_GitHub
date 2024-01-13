using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildScriptableObject : ScriptableObject
{
    //何もないとインスペクターが寂しいので変数を追加
    [SerializeField]
    string str;

    public ChildScriptableObject()
    {
        //初期アセット名を設定
        name = "NewChildScriptableObject";
    }
}

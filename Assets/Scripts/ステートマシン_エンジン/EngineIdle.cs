using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 速さ：停止
/// </summary>
public class EngineIdle : EngineState
{
    public override void Up(EngineBox engineBox)
    {
        Debug.Log("<color=red>Idle → Low</color>");
        //EngineBoxクラスにあるChangeState関数を使用する
        engineBox.ChangeState(new EngineRunningLow());
    }

    public override void Down(EngineBox engineBox)
    {
        Debug.Log("<color=black>チェンジ無し</color>");
        //EngineBoxクラスにあるChangeState関数を使用する
        engineBox.ChangeState(new EngineIdle());
    }

    public override void ShowCurrentState()
    {
        Debug.Log("<color=white>現在のステート : Idle</color>");
    }
}

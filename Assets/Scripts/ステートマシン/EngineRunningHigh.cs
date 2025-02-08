using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 速さ：フルスロットル
/// </summary>
public class EngineRunningHigh : EngineState
{
    public override void Up(EngineBox engineBox)
    {
        Debug.Log("<color=black>チェンジ無し</color>");
        //EngineBoxクラスにあるChangeState関数を使用する
        engineBox.ChangeState(new EngineRunningHigh());
    }

    public override void Down(EngineBox engineBox)
    {
        Debug.Log("<color=blue>High → Low</color>");
        //EngineBoxクラスにあるChangeState関数を使用する
        engineBox.ChangeState(new EngineRunningLow());
    }

    public override void ShowCurrentState()
    {
        Debug.Log("<color=white>現在のステート : High</color>");
    }
}

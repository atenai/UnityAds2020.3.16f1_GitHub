using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 速さ：通常速度
/// </summary>
public class EngineRunningLow : EngineState
{
    public override void Up(EngineBox engineBox)
    {
        Debug.Log("<color=red>Low → High</color>");
        //EngineBoxクラスにあるChangeState関数を使用する
        engineBox.ChangeState(new EngineRunningHigh());
    }

    public override void Down(EngineBox engineBox)
    {
        Debug.Log("<color=blue>Low → Idle</color>");
        //EngineBoxクラスにあるChangeState関数を使用する
        engineBox.ChangeState(new EngineIdle());
    }

    public override void ShowCurrentState()
    {
        Debug.Log("<color=white>現在のステート : Low</color>");
    }
}

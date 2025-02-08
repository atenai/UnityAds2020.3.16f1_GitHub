using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステートマシンを制御するクラス
/// </summary>
public class EngineBox
{
    [Tooltip("現在のステート")]
    EngineState currentState;

    /// <summary>
    /// コンストラクタ
    /// </summary> 
    public EngineBox()
    {
        //現在のステートをインスタンスしてIdleにステートする
        currentState = new EngineIdle();
    }

    public void EngineBoxUp()
    {
        //現在のステートにこのクラスの全てを入れる
        currentState.Up(this);
    }

    public void EngineBoxDown()
    {
        //現在のステートにこのクラスの全てを入れる
        currentState.Down(this);
    }

    public void ChangeState(EngineState nextState)
    {
        currentState = nextState;
    }

    public void NowState()
    {
        Debug.Log("<color=orange>現在のステート :" + currentState + "</color>");
        currentState.ShowCurrentState();
    }
}

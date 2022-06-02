using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineBox
{
    //コンストラクタ
    public EngineBox()
    {
        EngineBoxState = new EngineIdle();//最初はIdleの状態
    }
    public void EngineBoxUp()
    {
        EngineBoxState.up(this);
    }
    public void EngineBoxDown()
    {
        EngineBoxState.down(this);
    }
    public void changeState(EngineState newState)
    {
        EngineBoxState = newState;//新しい状態を入れる（EngineState型のクラスを入れる）
    }
    public void nowState()
    {
        Debug.Log(EngineBoxState);
    }
    public EngineState EngineBoxState;
}

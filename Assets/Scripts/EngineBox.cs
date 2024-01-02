using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineBox
{
    EngineState engineState;

    public EngineBox()
    {
        engineState = new EngineIdle();
    }

    public void EngineBoxUp()
    {
        engineState.Up(this);
    }

    public void EngineBoxDown()
    {
        engineState.Down(this);
    }

    public void ChangeState(EngineState newState)
    {
        engineState = newState;
    }

    public void NowState()
    {
        Debug.Log(engineState);
    }
}

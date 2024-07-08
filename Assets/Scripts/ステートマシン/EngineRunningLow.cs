using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineRunningLow : EngineState
{
    public override void Up(EngineBox engineBox)
    {
        Debug.Log("Low → High");
        engineBox.ChangeState(new EngineRunningHigh());
    }

    public override void Down(EngineBox engineBox)
    {
        Debug.Log("Low → Idle");
        engineBox.ChangeState(new EngineIdle());
    }

    public override void ShowCurrentState()
    {
        Debug.Log("State:Low");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineIdle : EngineState
{
    public override void Up(EngineBox engineBox)
    {
        Debug.Log("Idle → Low");
        engineBox.ChangeState(new EngineRunningLow());
    }

    public override void Down(EngineBox engineBox)
    {
        Debug.Log("No Change");
        engineBox.ChangeState(new EngineIdle());
    }

    public override void ShowCurrentState()
    {
        Debug.Log("State:Idle");
    }
}

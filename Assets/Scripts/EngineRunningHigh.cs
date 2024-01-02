using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineRunningHigh : EngineState
{
    public override void Up(EngineBox engineBox)
    {
        Debug.Log("No Change");
        engineBox.ChangeState(new EngineRunningHigh());
    }
    public override void Down(EngineBox engineBox)
    {
        Debug.Log("High → Low");
        engineBox.ChangeState(new EngineRunningLow());
    }
    public override void ShowCurrentState()
    {
        Debug.Log("State:High");
    }
}

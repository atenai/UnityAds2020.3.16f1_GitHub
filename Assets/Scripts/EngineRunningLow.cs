using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineRunningLow : EngineState
{
    public override void up(EngineBox pEBox)
    {
        Debug.Log("Low ÅÀ High");
        pEBox.changeState(new EngineRunningHigh());
    }
    public override void down(EngineBox pEBox)
    {
        Debug.Log("Low ÅÀ Idle");
        pEBox.changeState(new EngineIdle());
    }
    public override void showCurrentState()
    {
        Debug.Log("State:Low");
    }
}

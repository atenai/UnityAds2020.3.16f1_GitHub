using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineRunningHigh : EngineState
{
    public override void up(EngineBox pEBox)
    {
        Debug.Log("No Change");
        pEBox.changeState(new EngineRunningHigh());
    }
    public override void down(EngineBox pEBox)
    {
        Debug.Log("High ÅÀ Low");
        pEBox.changeState(new EngineRunningLow());
    }
    public override void showCurrentState()
    {
        Debug.Log("State:High");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineIdle : EngineState
{
    public override void up(EngineBox pEBox)
    {
        Debug.Log("Idle ÅÀ Low");
        pEBox.changeState(new EngineRunningLow());
    }
    public override void down(EngineBox pEBox)
    {
        Debug.Log("No Change");
        pEBox.changeState(new EngineIdle());
    }
    public override void showCurrentState()
    {
        Debug.Log("State:Idle");
    }
}

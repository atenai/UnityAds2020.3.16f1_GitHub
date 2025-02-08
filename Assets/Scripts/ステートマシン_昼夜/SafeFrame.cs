using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeFrame
{
    private State currentState = DayState.GetInstance();

    public void SetClock(int hour)
    {
        currentState.DoClock(this, hour);
    }

    public void SetUpdate()
    {
        currentState.DoUpdate();
    }

    public void ChangeState(State nextState)
    {
        Debug.Log(currentState + "から" + nextState + "へ状態が変化しました。");
        currentState = nextState;
    }
}

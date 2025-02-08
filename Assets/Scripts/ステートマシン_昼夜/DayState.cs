using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayState : State
{
    private static DayState singleton = new DayState();

    public static State GetInstance()
    {
        return singleton;
    }

    public override void DoClock(SafeFrame safeFrame, int hour)
    {
        //もしhourが9時以下　または　17時以上なら中身を実行する
        if (hour < 9 || 17 <= hour)
        {
            safeFrame.ChangeState(NightState.GetInstance());
        }
    }

    public override void DoUpdate()
    {
        Debug.Log("昼になりました。");
    }
}

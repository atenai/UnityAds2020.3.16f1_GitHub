using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightState : State
{
    private static NightState singleton = new NightState();

    public static State GetInstance()
    {
        return singleton;
    }

    public override void DoClock(SafeFrame safeFrame, int hour)
    {
        //もしhourが9時以上　かつ　17時以下なら中身を実行する
        if (9 <= hour && hour < 17)
        {
            //状態を昼に変化させる
            safeFrame.ChangeState(DayState.GetInstance());
        }
    }

    public override void DoUpdate()
    {
        Debug.Log("夜になりました。");
    }
}

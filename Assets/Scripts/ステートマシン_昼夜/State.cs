using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void DoClock(SafeFrame safeFrame, int hour);
    public abstract void DoUpdate();
}

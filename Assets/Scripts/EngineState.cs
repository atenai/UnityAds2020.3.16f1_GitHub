using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EngineState
{
    public abstract void up(EngineBox pEBox);
    public abstract void down(EngineBox pEBox);
    public abstract void showCurrentState();
}

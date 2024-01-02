using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EngineState
{
    public abstract void Up(EngineBox engineBox);
    public abstract void Down(EngineBox engineBox);
    public abstract void ShowCurrentState();
}

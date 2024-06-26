using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorScope : GUI.Scope
{
    private readonly Color color;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public BackgroundColorScope(Color color)
    {
        this.color = GUI.backgroundColor;
        GUI.backgroundColor = color;
    }

    protected override void CloseScope()
    {
        GUI.backgroundColor = color;
    }
}

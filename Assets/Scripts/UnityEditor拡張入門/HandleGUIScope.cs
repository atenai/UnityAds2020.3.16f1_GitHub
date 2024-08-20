using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class HandleGUIScope : GUI.Scope
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public HandleGUIScope()
    {
        Handles.BeginGUI();
    }

    protected override void CloseScope()
    {
        Handles.EndGUI();
    }
}

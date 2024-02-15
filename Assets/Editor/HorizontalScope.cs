using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HorizontalScope : GUI.Scope
{
    public HorizontalScope()
    {
        EditorGUILayout.BeginHorizontal();
    }

    protected override void CloseScope()
    {
        EditorGUILayout.EndHorizontal();
    }
}

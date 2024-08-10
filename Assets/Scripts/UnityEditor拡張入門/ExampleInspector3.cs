#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Example18.csと紐づいているクラス
/// </summary> 
[CustomEditor(typeof(Example18))]
public class ExampleInspecto3 : Editor
{
    void OnSceneGUI()
    {
        var component = target as Example18;

        var transform = component.transform;

        if (Tools.current == Tool.Move)
        {
            transform.rotation = Handles.RotationHandle(transform.rotation, transform.position);
        }
        else if (Tools.current == Tool.Rotate)
        {
            transform.position = Handles.PositionHandle(transform.position, transform.rotation);
        }
    }
}
#endif
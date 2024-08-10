#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Example17.csと紐づいているクラス
/// </summary> 
[CustomEditor(typeof(Example17))]
public class ExampleInspecto2 : Editor
{
    void OnSceneGUI()
    {

        Tools.current = Tool.None;
        var component = target as Example17;

        var transform = component.transform;
        transform.position = Handles.PositionHandle(transform.position, transform.rotation);

    }
}
#endif
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

/// <summary>
/// Example20.csと紐づいているクラス
/// </summary> 
[CustomEditor(typeof(Example20))]
public class ExampleInspecto5 : Editor
{
    void OnSceneGUI()
    {
        Tools.current = Tool.None;
        var component = target as Example20;
        var transform = component.transform;

        transform.position = PositionHandle(transform);
    }

    Vector3 PositionHandle(Transform transform)
    {
        var position = transform.position;

        Handles.color = Handles.xAxisColor;
        position = Handles.Slider(position, transform.right);//X軸

        Handles.color = Handles.yAxisColor;
        position = Handles.Slider(position, transform.up);//Y軸

        Handles.color = Handles.zAxisColor;
        position = Handles.Slider(position, transform.forward);//Z軸

        return position;
    }
}
#endif
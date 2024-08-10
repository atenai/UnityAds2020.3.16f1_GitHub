#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

/// <summary>
/// Example19.csと紐づいているクラス
/// </summary> 
[CustomEditor(typeof(Example19))]
public class ExampleInspecto4 : Editor
{
    void OnSceneGUI()
    {
        Tools.current = Tool.None;
        var component = target as Example19;
        PositionHandle(component.transform);
    }

    void PositionHandle(Transform transform)
    {
        Handles.color = Handles.xAxisColor;
        Handles.Slider(transform.position, transform.right);//X軸

        Handles.color = Handles.yAxisColor;
        Handles.Slider(transform.position, transform.up);//Y軸

        Handles.color = Handles.zAxisColor;
        Handles.Slider(transform.position, transform.forward);//Z軸
    }
}
#endif
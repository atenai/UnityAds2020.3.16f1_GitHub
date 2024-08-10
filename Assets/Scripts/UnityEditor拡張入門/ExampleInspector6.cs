#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

/// <summary>
/// Example21.csと紐づいているクラス
/// </summary> 
[CustomEditor(typeof(Example21))]
public class ExampleInspecto6 : Editor
{
    Vector3 snap;

    void OnSceneGUI()
    {
        Tools.current = Tool.None;
        var component = target as Example21;
        var transform = component.transform;

        transform.position = PositionHandle(transform);
    }

    void OnEnable()
    {
        //SnapSettingsの値を取得する
        var snapX = EditorPrefs.GetFloat("MoveSnapX", 1f);
        var snapY = EditorPrefs.GetFloat("MoveSnapY", 1f);
        var snapZ = EditorPrefs.GetFloat("MoveSnapZ", 1f);
        snap = new Vector3(snapX, snapY, snapZ);
    }

    Vector3 PositionHandle(Transform transform)
    {
        var position = transform.position;

        var size = 1;
        //var size = HandleUtility.GetHandleSize(position);

        //X軸
        Handles.color = Handles.xAxisColor;
        position = Handles.Slider(position, transform.right, size, Handles.ArrowHandleCap, snap.x);

        //Y軸
        Handles.color = Handles.yAxisColor;
        position = Handles.Slider(position, transform.up, size, Handles.ArrowHandleCap, snap.y);

        //Z軸
        Handles.color = Handles.zAxisColor;
        position = Handles.Slider(position, transform.forward, size, Handles.ArrowHandleCap, snap.z);

        return position;
    }
}
#endif
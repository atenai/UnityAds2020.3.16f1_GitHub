#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

/// <summary>
/// Example22.csと紐づいているクラス
/// </summary> 
[CustomEditor(typeof(Example22))]
public class ExampleInspecto7 : Editor
{
    Vector3 snap;
    float size = 1;

    void OnSceneGUI()
    {
        Tools.current = Tool.None;
        var component = target as Example22;
        var transform = component.transform;

        transform.position = Handles.FreeMoveHandle(transform.position, size, snap, Handles.RectangleHandleCap);
    }

    void OnEnable()
    {
        //SnapSettingsの値を取得する
        var snapX = EditorPrefs.GetFloat("MoveSnapX", 1f);
        var snapY = EditorPrefs.GetFloat("MoveSnapY", 1f);
        var snapZ = EditorPrefs.GetFloat("MoveSnapZ", 1f);
        snap = new Vector3(snapX, snapY, snapZ);
    }
}
#endif
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

/// <summary>
/// Example25.csと紐づいているクラス
/// </summary> 
[CustomEditor(typeof(Example25))]
public class ExampleInspecto10 : Editor
{
    void OnSceneGUI()
    {
        //ここは様式美
        Tools.current = Tool.None;
        var component = target as Example25;
        //ここは様式美

        var vertexes = component.vertexes;

        for (int i = 0; i < vertexes.Length; i++)
        {
            vertexes[i] = Handles.PositionHandle(vertexes[i], Quaternion.identity);
        }

        Handles.DrawAAPolyLine(vertexes);
    }

    void OnEnable()
    {

    }
}
#endif
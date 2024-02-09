using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Example2 : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("name"));

        //他、さまざまな処理
        serializedObject.ApplyModifiedProperties();
    }
}

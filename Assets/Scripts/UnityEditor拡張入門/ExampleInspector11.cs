#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditorInternal;

/// <summary>
/// Example26.csと紐づいているクラス
/// </summary> 
[CustomEditor(typeof(Example26))]
public class ExampleInspecto11 : Editor
{
    ReorderableList reorderableList;
    Example26 component;

    void OnEnable()
    {
        //ここは様式美
        Tools.current = Tool.None;
        component = target as Example26;
        //ここは様式美

        reorderableList = new ReorderableList(component.vertexes, typeof(Vector3));

        reorderableList.drawElementCallback = (rect, index, isActive, isFocused) =>
        {
            component.vertexes[index] = EditorGUI.Vector3Field(rect, GUIContent.none, component.vertexes[index]);
        };

        reorderableList.onAddCallback = (list) =>
        {
            ArrayUtility.Add(ref component.vertexes, Vector3.zero);

            ActiveEditorTracker.sharedTracker.ForceRebuild();
        };

        reorderableList.onRemoveCallback = (list) =>
        {
            ArrayUtility.Remove(ref component.vertexes, component.vertexes[list.index]);
            ActiveEditorTracker.sharedTracker.ForceRebuild();
        };

        reorderableList.onChangedCallback = (list) => SceneView.RepaintAll();
    }

    public override void OnInspectorGUI()
    {
        reorderableList.DoLayoutList();
    }
}
#endif
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(Example13))]
public class ExampleInspector : Editor
{
    ReorderableList reorderableList;

    void OnEnable()
    {
        reorderableList = new ReorderableList(serializedObject, serializedObject.FindProperty("texts"));

        var prop = serializedObject.FindProperty("texts");

        reorderableList = new ReorderableList(serializedObject, prop);

        reorderableList.drawElementCallback = (rect, index, isActive, isFocused) =>
        {
            var element = prop.GetArrayElementAtIndex(index);
            rect.height -= 4;
            rect.y += 2;
            EditorGUI.PropertyField(rect, element);
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        reorderableList.DoLayoutList();

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
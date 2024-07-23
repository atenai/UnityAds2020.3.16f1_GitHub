#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

/// <summary>
/// Example14.csと紐づいているクラス
/// Character6.csと紐づいているクラス
/// CharacterDrawe1.csと紐づいているクラス 
/// </summary> 
[CustomEditor(typeof(Example14))]
public class ExampleInspecto1 : Editor
{
    ReorderableList reorderableList;

    void OnEnable()
    {
        var prop = serializedObject.FindProperty("characters");

        reorderableList = new ReorderableList(serializedObject, prop);

        reorderableList.elementHeight = 68;

        reorderableList.drawElementCallback = (rect, index, isActive, isFocused) =>
        {
            var element = prop.GetArrayElementAtIndex(index);
            rect.height -= 4;
            rect.y += 2;
            EditorGUI.PropertyField(rect, element);
        };

        var defaultColor = GUI.backgroundColor;

        reorderableList.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, prop.displayName);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        reorderableList.DoLayoutList();

        serializedObject.ApplyModifiedProperties();
    }

}
#endif
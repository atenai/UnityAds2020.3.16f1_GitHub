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

        reorderableList.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, prop.displayName);

        reorderableList.drawElementBackgroundCallback = (rect, index, isActive, isFocused) =>
        {
            GUI.backgroundColor = Color.yellow;
        };

        reorderableList.drawElementBackgroundCallback = (rect, index, isActive, isFocused) =>
        {
            if (Event.current.type == EventType.Repaint)
            {
                EditorStyles.miniButton.Draw(rect, false, isActive, isFocused, false);
            }
        };

        reorderableList.onAddCallback += (list) =>
        {
            //要素の追加
            prop.arraySize++;

            //最後の要素を選択状態にする
            list.index = prop.arraySize - 1;

            //追加した要素に文字列を追加する（配列がstring[]前提）
            var element = prop.GetArrayElementAtIndex(list.index);
            element.stringValue = "New String" + list.index;
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
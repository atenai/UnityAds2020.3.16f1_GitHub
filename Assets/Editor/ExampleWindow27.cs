using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class ExampleWindow27 : EditorWindow, IHasCustomMenu
{
    public void AddItemsToMenu(GenericMenu menu)
    {
        menu.AddItem(new GUIContent("example"), false, () => { });

        menu.AddItem(new GUIContent("example2"), true, () => { });
    }

    [MenuItem("Kashiwabara/Example27")]
    static void Open()
    {
        GetWindow<ExampleWindow27>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class ExampleWindow28 : EditorWindow
{
    [MenuItem("Kashiwabara/Example28")]
    static void Open()
    {
        var window = GetWindow<ExampleWindow28>();
        window.maxSize = window.minSize = new Vector2(300, 300);
    }
}

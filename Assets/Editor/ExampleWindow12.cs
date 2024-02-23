using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

/// <summary>
/// 複数の存在を許可するEditorWindow
/// </summary>
public class ExampleWindow12 : EditorWindow
{
    [MenuItem("Kashiwabara/Example12")]
    static void Open()
    {
        var exampleWindow = CreateInstance<ExampleWindow12>();
        exampleWindow.Show();
    }


    void OnGUI()
    {

    }
}

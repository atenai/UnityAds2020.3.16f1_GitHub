using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

/// <summary>
/// 何かを作るときに使用するウィンドウ
/// </summary>
public class ExampleWindow24 : ScriptableWizard
{
    [MenuItem("Kashiwabara/Example24")]
    static void Open()
    {
        DisplayWizard<ExampleWindow24>("Example Wizard");
    }

    void OnWizardUpdate()
    {
        Debug.Log("Update");
    }
}

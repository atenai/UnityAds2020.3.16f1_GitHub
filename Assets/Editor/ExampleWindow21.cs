using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

/// <summary>
/// 何かを作るときに使用するウィンドウ
/// </summary>
public class ExampleWindow21 : ScriptableWizard
{
    public string gameObjectName;

    [MenuItem("Kashiwabara/Example21")]
    static void Open()
    {
        DisplayWizard<ExampleWindow21>("Example Wizard");
    }
}

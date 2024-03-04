using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

/// <summary>
/// 何かを作るときに使用するウィンドウ
/// </summary>
public class ExampleWindow22 : ScriptableWizard
{
    public string gameObjectName;

    [MenuItem("Kashiwabara/Example22")]
    static void Open()
    {
        DisplayWizard<ExampleWindow22>("Example Wizard");
    }

    void OnWizardCreate()
    {
        new GameObject(gameObjectName);
    }
}

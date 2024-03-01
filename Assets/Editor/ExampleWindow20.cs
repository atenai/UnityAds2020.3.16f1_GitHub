using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

/// <summary>
/// 何かを作るときに使用するウィンドウ
/// </summary>
public class ExampleWindow20 : ScriptableWizard
{

    [MenuItem("Kashiwabara/Example20")]
    static void Open()
    {
        DisplayWizard<ExampleWindow20>("Example Wizard");
    }
}

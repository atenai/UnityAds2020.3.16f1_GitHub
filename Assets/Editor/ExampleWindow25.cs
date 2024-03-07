using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

/// <summary>
/// 何かを作るときに使用するウィンドウ
/// </summary>
public class ExampleWindow25 : ScriptableWizard
{
    public string gameObjectName;

    [MenuItem("Kashiwabara/Example25")]
    static void Open()
    {
        DisplayWizard<ExampleWindow25>("Example Wizard");
    }

    protected override bool DrawWizardGUI()
    {
        EditorGUILayout.LabelField("Label");
        //falseを返すことでOnWizardUpdateが呼び出されなくなる
        return true;
    }
}

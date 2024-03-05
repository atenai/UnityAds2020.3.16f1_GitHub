using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

/// <summary>
/// 何かを作るときに使用するウィンドウ
/// </summary>
public class ExampleWindow23 : ScriptableWizard
{
    public string gameObjectName;

    [MenuItem("Kashiwabara/Example23")]
    static void Open()
    {
        DisplayWizard<ExampleWindow23>("Example Wizard", "Create", "Find");
    }

    void OnWizardCreate()
    {
        new GameObject(gameObjectName);
    }

    void OnWizardOtherButton()
    {
        var gameObject = GameObject.Find(gameObjectName);

        if (gameObject == null)
        {
            Debug.Log("ゲームオブジェクトが見つかりません");
        }
    }
}

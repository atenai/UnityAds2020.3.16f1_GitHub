using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class ExampleWindow38
{
    [MenuItem("Kashiwabara/Example38")]
    static void Example()
    {
        var menuPath = "Kashiwabara/Example38";
        var @checked = Menu.GetChecked(menuPath);
        Menu.SetChecked(menuPath, !@checked);
    }
}

#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
using UnityEditor.Callbacks;
using System.IO;
using UnityEditor.iOS.Xcode;
using UnityEditor.SceneManagement;
using System.Linq;
using UnityEditor.SearchService;

public class ExampleWindow44 : EditorWindow
{
    [MenuItem("Kashiwabara/Example44")]
    static void CheckModifierKeysChanged()
    {
        GetWindow<ExampleWindow44>();
    }

    void OnEnable()
    {
        EditorApplication.modifierKeysChanged += Repaint;
    }

    void OnGUI()
    {
        GUILayout.Label(Event.current.modifiers.ToString());
    }
}
#endif
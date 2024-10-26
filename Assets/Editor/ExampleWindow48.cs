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

public class ExampleWindow48 : EditorWindow
{
    [MenuItem("Kashiwabara/Example48")]
    static void CreateTextAsset()
    {
        var text = "text";
        File.WriteAllText("Assets/New TextAsset.txt", text);
    }
}
#endif
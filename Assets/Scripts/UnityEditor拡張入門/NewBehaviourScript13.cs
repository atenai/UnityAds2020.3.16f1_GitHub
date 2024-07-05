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

public class NewBehaviourScript13
{
    [InitializeOnLoadMethod]
    static void RunMethod()
    {
        Debug.Log("InitializeOnLoadMethod");
    }
}
#endif
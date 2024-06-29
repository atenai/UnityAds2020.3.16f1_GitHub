using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
using UnityEditor.Callbacks;
using System.IO;
using UnityEditor.iOS.Xcode;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class NewBehaviourScript11
{
    static NewBehaviourScript11()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode)
        {
            return;
        }
        Debug.Log("call");
    }
}

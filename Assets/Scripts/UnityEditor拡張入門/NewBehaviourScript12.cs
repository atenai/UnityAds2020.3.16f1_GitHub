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
public class NewBehaviourScript12
{
    static NewBehaviourScript12()
    {
        //10秒以内であれば起動時と判断する
        if (10 < EditorApplication.timeSinceStartup)
        {
            return;
        }
        Debug.Log("起動時に呼び出される");
    }
}

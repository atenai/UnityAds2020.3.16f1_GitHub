using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
using UnityEditor.Callbacks;
using System.IO;
using UnityEditor.iOS.Xcode;
using UnityEditor.SceneManagement;

public class NewBehaviourScript15
{
    // [InitializeOnLoadMethod]
    // static void ChangeBundleIdentifier()
    // {
    //     //プラットフォームごとにbundleIdentifierを切り替える
    //     EditorUserBuildSettings.activeBuildTargetChanged += () =>
    //     {
    //         var bundleIdentifier = "com.kyusyukeigo.superapp";

    //         switch (EditorUserBuildSettings.activeBuildTarget)
    //         {
    //             case BuildTarget.iOS:
    //                 bundleIdentifier += ".ios";
    //                 break;

    //             case BuildTarget.Android:
    //                 bundleIdentifier += ".android";
    //                 break;

    //             case BuildTarget.WSAPlayer:
    //                 bundleIdentifier += ".wp";
    //                 break;

    //             default:
    //                 break;
    //         }

    //         PlayerSettings.bundleIdentifier = bundleIdentifier;
    //     };
    // }
}

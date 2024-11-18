// #if UNITY_EDITOR
// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEditor;
// using UnityEngine;

// [InitializeOnLoad]
// public class EditorApplicationUtility
// {
//     public static Action<EditorWindow> focusedWindowChanged;

//     static EditorWindow currentFocusedWindow;

//     static EditorApplicationUtility()
//     {
//         EditorApplication.update += FocusedWindowChanged;
//     }

//     static void FocusedWindowChanged()
//     {
//         if (currentFocusedWindow != EditorWindow.focusedWindow)
//         {
//             currentFocusedWindow = EditorWindow.focusedWindow;
//             focusedWindowChanged(currentFocusedWindow);
//         }
//     }
// }

// [InitializeOnLoad]
// public class Test
// {
//     static Test()
//     {
//         EditorApplicationUtility.focusedWindowChanged += (window) =>
//         {
//             Debug.Log(window);
//         };
//     }
// }
// #endif
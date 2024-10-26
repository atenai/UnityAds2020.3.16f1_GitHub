// #if UNITY_EDITOR
// using System.Collections;
// using System.Collections.Generic;
// using System.Data.Common;
// using UnityEditor;
// using UnityEngine;


// /// <summary>
// /// エディタウィンドウを作る為の金型
// /// </summary>
// public class NewBehaviourScript25 : EditorWindow
// {

//     [MenuItem("Kashiwabara/SpriteEditor")]
//     static void Open()
//     {
//         GetWindow<NewBehaviourScript25>();
//     }

//     private Sprite sprite1, sprite2;

//     void OnGUI()
//     {
//         sprite1 = CustomEditorGUI.SpriteField(new Rect(134, 1, 128, 128), sprite1);
//         sprite2 = CustomEditorGUILayout.SpriteField(sprite2, GUILayout.Width(128), GUILayout.Height(128));
//     }
// }
// #endif
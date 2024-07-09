// #if UNITY_EDITOR
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;
// using UnityEngine.AI;
// using UnityEditor.Callbacks;
// using System;
// using System.IO;
// using UnityEditor.iOS.Xcode;
// using UnityEditor.SceneManagement;
// using System.Linq;
// using UnityEditor.SearchService;
// using UnityEngine.Experimental;
// using UnityEngine.Networking;

// public class NewBehaviourScript18
// {
//     [MenuItem("Assets/Get Texture")]
//     static void TestWWW()
//     {
//         //画像のURL 
//         var www = UnityWebRequest.GetTexture("http:// placehold. it/ 350 x 150");//画像を取得して保存する

//         //画像を取得して保存する
//         EditorUnityWebRequest(www, () =>
//         {
//             var downloadHandler = (DownloadHandlerTexture)www.downloadHandler;

//             var assetPath = "Assets/New Texture.png";

//             File.WriteAllBytes(assetPath, downloadHandler);

//             AssetDatabase.ImportAsset(assetPath);
//         });
//     }

//     static void EditorUnityWebRequest(UnityWebRequest www, Action callback)
//     {
//         www.Send();

//         EditorApplication.CallbackFunction update = null;

//         update = () =>
//         {
//             //毎フレームチェック
//             if (www.isDone && string.IsNullOrEmpty(www.error))
//             {
//                 callback();

//                 EditorApplication.update -= update;
//             }
//         };

//         EditorApplication.update += update;
//     }
// }
// #endif
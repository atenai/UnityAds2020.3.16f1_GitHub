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
using TMPro;

/// <summary>
/// ヒエラルキーにあるゲームオブジェクトのコンポーネントのアイコンを表示する（消すな！！）
/// </summary>
public class HierarchyIcon
{
    [InitializeOnLoadMethod]
    static void DrawComponentIcons()
    {
        EditorApplication.hierarchyWindowItemOnGUI += (instanceID, selectionRect) =>
        {
            //インスタンスIDからゲームオブジェクトを取得
            var go = (GameObject)EditorUtility.InstanceIDToObject(instanceID);

            if (go == null)
            {
                return;
            }

            var position = new Rect(selectionRect)
            {
                width = 16,
                height = 16,
                x = Screen.width - 20
            };

            foreach (var component in go.GetComponents<Component>())
            {
                //Transformは全ゲームオブジェクトにあるので
                //無駄な情報な為、表示しない
                if (component is Transform)
                {
                    continue;
                }

                var icon = AssetPreview.GetMiniThumbnail(component);

                GUI.Label(position, icon);

                position.x -= 16;
            }
        };
    }
}
#endif
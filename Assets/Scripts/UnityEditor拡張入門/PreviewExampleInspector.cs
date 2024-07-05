#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PreviewExample))]
public class PreviewExampleInspector : Editor
{
    public override bool HasPreviewGUI()
    {
        return true;
    }

    public override GUIContent GetPreviewTitle()
    {
        return new GUIContent("プレビュー名");
    }

    public override void OnPreviewSettings()
    {
        GUIStyle preLabel = new GUIStyle("preLabel");
        GUIStyle preButton = new GUIStyle("preButton");

        GUILayout.Label("ラベル", preLabel);
        GUILayout.Button("ボタン", preButton);
    }

    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
        GUI.Box(r, "Preview");
    }
}
#endif
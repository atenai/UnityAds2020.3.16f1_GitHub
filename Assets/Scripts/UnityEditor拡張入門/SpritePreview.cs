using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPreview(typeof(AnimationClip))]
public class SpritePreview : ObjectPreview
{
    private GUIContent previewTitle = new GUIContent("Sprites");

    public override bool HasPreviewGUI()
    {
        return true;
    }

    public override GUIContent GetPreviewTitle()
    {
        return previewTitle;
    }

    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
        GUI.Box(r, "表示領域");
    }
}


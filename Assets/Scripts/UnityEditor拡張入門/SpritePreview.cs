using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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

    private Sprite[] GetSprites(AnimationClip animationClip)
    {
        var sprites = new Sprite[0];

        if (animationClip != null)
        {
            var editorCurveBinding = EditorCurveBinding.PPtrCurve("", typeof(SpriteRenderer), "m_Sprite");

            var objectReferenceKeyframes = AnimationUtility.GetObjectReferenceCurve(animationClip, editorCurveBinding);

            sprites = objectReferenceKeyframes.Select(objectReferenceKeyframe => objectReferenceKeyframe.value).OfType<Sprite>().ToArray();
        }

        return sprites;
    }
}


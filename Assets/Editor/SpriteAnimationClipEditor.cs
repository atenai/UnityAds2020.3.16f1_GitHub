using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CanEditMultipleObjects]
[CustomEditor(typeof(AnimationClip))]
public class SpriteAnimationClipEditor : OverrideEditor
{
	protected override Editor GetBaseEditor()
	{
		Editor editor = null;

		var baseType = System.Type.GetType("UnityEditor.AnimationClipEditor, UnityEditor");

		CreateCachedEditor(targets, baseType, ref editor);
		return editor;
	}

	private Sprite[] GetSprites(AnimationClip animationClip)
	{
		var sprites = new Sprite[0];

		if (animationClip != null)
		{
			var editorCurveBinding = EditorCurveBinding.PPtrCurve("", typeof(SpriteRenderer), "m_Sprite");

			var objectReferenceKeyframes = AnimationUtility.GetObjectReferenceCurve(animationClip, editorCurveBinding);

			var _sprites = objectReferenceKeyframes.Select(objectReferenceKeyframe => objectReferenceKeyframe.value).OfType<Sprite>();

			foreach (var sprite in _sprites)
			{
				AssetPreview.GetAssetPreview(sprite);
			}
			sprites = _sprites.ToArray();
		}

		return sprites;
	}
}

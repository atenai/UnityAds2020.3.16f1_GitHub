using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CanEditMultipleObjects]
[CustomEditor(typeof(AnimationClip))]
public class SpriteAnimationClipEditor : OverrideEditor
{
	Sprite[] sprites = new Sprite[0];

	protected override Editor GetBaseEditor()
	{
		Editor editor = null;

		var baseType = System.Type.GetType("UnityEditor.AnimationClipEditor, UnityEditor");

		CreateCachedEditor(targets, baseType, ref editor);
		return editor;
	}

	private Sprite[] GetSprites(AnimationClip animationClip)
	{
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

	public override bool HasPreviewGUI()
	{
		return true;
	}

	public override void OnInteractivePreviewGUI(Rect r, GUIStyle background)
	{
		//スプライトがなければ通常（3D）のプレビュー画面にする
		if (sprites.Length != 0)
		{
			var texture = AssetPreview.GetAssetPreview(sprites[0]);

			EditorGUI.DrawTextureTransparent(r, texture, ScaleMode.ScaleToFit);
		}
		else
		{
			baseEditor.OnInteractivePreviewGUI(r, background);
		}

		// SpriteAnimationSetting setting;
		// if(dic.TryGetValue(target, out setting))
		// {
		// 	var currentSpriteNum = Mathf.FloorToInt(TimeControl.GetCurrentTime(setting.stopTime * setting.frameRate));
		// 	var sprite = setting.sprites[currentSpriteNum];
		// 	var texture = AssetPreview.GetAssetPreview(sprite);

		// 	if(texture != null)
		// 	{
		// 		EditorGUI.DrawTextureTransparent(r, texture, ScaleMode.ScaleToFit);
		// 	}else{
		// 		baseEditor.OnInteractivePreviewGUI(r, background);
		// 	}
		// }
	}

	private bool isPlaying = false;

	public override void OnPreviewSettings()
	{
		var playButtonContent = EditorGUIUtility.IconContent("PlayButton");

		var pauseButtonContent = EditorGUIUtility.IconContent("PauseButton");

		var previewButtonSettingsStyle = new GUIStyle("preButton");

		var buttonContent = isPlaying ? pauseButtonContent : playButtonContent;

		isPlaying = GUILayout.Toggle(isPlaying, buttonContent, previewButtonSettingsStyle);
	}
}

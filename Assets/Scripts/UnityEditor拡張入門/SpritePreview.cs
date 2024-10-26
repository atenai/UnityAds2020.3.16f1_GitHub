// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using UnityEditor;
// using UnityEngine;
// using UnityEngine.UI;

// [CustomPreview(typeof(AnimationClip))]
// public class SpritePreview : ObjectPreview
// {
//     private GUIContent previewTitle = new GUIContent("Sprites");

//     public override void Initialize(Object[] targets)
//     {
//         base.Initialize(targets);

//         var sprites = new Object[0];

//         foreach (AnimationClip animationClip in targets)
//         {
//             ArrayUtility.AddRange(ref sprites, GetSprites(animationClip));
//         }

//         //ここでスプライトのプレビュー用テクスチャを生成＆キャッシュさせる
//         foreach (var sprite in sprites)
//         {
//             AssetPreview.GetAssetPreview(sprite);
//         }

//         m_Targets = sprites;
//     }

//     public override bool HasPreviewGUI()
//     {
//         return true;
//     }

//     public override GUIContent GetPreviewTitle()
//     {
//         return previewTitle;
//     }

//     public override void OnPreviewGUI(Rect r, GUIStyle background)
//     {
//         GUI.Box(r, "表示領域");

//         var sprites = GetSprites(target as AnimationClip);

//         var guiContents = sprites.Select(s => new GUIContent(s.name, AssetPreview.GetAssetPreview(s))).ToArray();

//         GUI.SelectionGrid(r, -1, guiContents, 2, EditorStyles.whiteBoldLabel);

//         var previewTexture = AssetPreview.GetAssetPreview(target);

//         EditorGUI.DrawTextureTransparent(r, previewTexture);
//     }

//     private Sprite[] GetSprites(AnimationClip animationClip)
//     {
//         var sprites = new Sprite[0];

//         if (animationClip != null)
//         {
//             var editorCurveBinding = EditorCurveBinding.PPtrCurve("", typeof(SpriteRenderer), "m_Sprite");

//             var objectReferenceKeyframes = AnimationUtility.GetObjectReferenceCurve(animationClip, editorCurveBinding);

//             sprites = objectReferenceKeyframes.Select(objectReferenceKeyframe => objectReferenceKeyframe.value).OfType<Sprite>().ToArray();
//         }

//         return sprites;
//     }
// }


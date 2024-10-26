// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;

// public class CustomEditorGUI
// {
//     private static GUIStyle spriteStyle = new GUIStyle();

//     public static Sprite SpriteField(Rect rect, Sprite sprite)
//     {
//         var evt = Event.current;
//         int id = GUIUtility.GetControlID(FocusType.Keyboard, rect);

//         if (evt.type == EventType.Repaint)
//         {
//             //サムネ形式の背景を描画
//             EditorStyles.objectFieldThumb.Draw(rect, GUIContent.none, id, false);

//             if (sprite)
//             {
//                 //スプライトからプレビュー用のテクスチャを取得
//                 var spriteTexture = AssetPreview.GetAssetPreview(sprite);
//                 if (spriteTexture)
//                 {
//                     spriteStyle.normal.background = spriteTexture;
//                     //スプライトを描画
//                     spriteStyle.Draw(rect, false, false, false, false);
//                 }
//             }
//         }

//         if (rect.Contains(evt.mousePosition))
//         {
//             var on = DragAndDrop.activeControlID == id;
//             EditorStyles.objectFieldThumb.Draw(rect, GUIContent.none, id, on);

//             switch (evt.type)
//             {
//                 case EventType.DragUpdated:
//                 case EventType.DragPerform:

//                     if (DragAndDrop.objectReferences.Length == 1)
//                     {
//                         DragAndDrop.AcceptDrag();
//                     }

//                     DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
//                     break;

//                 case EventType.DragExited:

//                     if (DragAndDrop.objectReferences.Length == 1)
//                     {
//                         var reference = DragAndDrop.objectReferences[0] as Sprite;
//                         if (reference != null)
//                         {
//                             sprite = reference;
//                             HandleUtility.Repaint();
//                         }
//                     }
//                     break;
//             }
//         }

//         var buttonRect = new Rect(rect);
//         //加工
//         buttonRect.x += buttonRect.width * 0.5f;
//         buttonRect.width *= 0.5f;
//         buttonRect.y += rect.height - 16;
//         buttonRect.height = 16;

//         //キーを押した時
//         //エンターキーである時
//         //そして操作しているのがこのGUIであるとき
//         var hitEnter = evt.type == EventType.KeyDown && (evt.keyCode == KeyCode.Return || evt.keyCode == KeyCode.KeypadEnter) && EditorGUIUtility.keyboardControl == id;
//         //ボタンを押した時、またはエンターキーを押した時にオブジェクトピッカーを表示
//         if (GUI.Button(buttonRect, "select", EditorStyles.objectFieldThumb.name + "Overlay2") || hitEnter)
//         {
//             //どのGUIで表示したか判断できるようにコントロールIDを渡す
//             EditorGUIUtility.ShowObjectPicker<Sprite>(sprite, false, "", id);
//             evt.Use();
//             GUIUtility.ExitGUI();
//         }

//         //オブジェクトピッカーがこのGUIのためのものであるか判断
//         if (evt.commandName == "ObjectSelectorUpdated" && id == EditorGUIUtility.GetObjectPickerControlID())
//         {
//             sprite = EditorGUIUtility.GetObjectPickerObject() as Sprite;

//             //描画するスプライトが変更されたので再描画
//             HandleUtility.Repaint();
//         }

//         return sprite;
//     }
// }

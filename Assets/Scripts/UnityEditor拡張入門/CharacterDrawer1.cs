#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//PropertyDrawerとはピュアC#で書かれた[Serializable]のついたクラスをカスタマイズするもの

/// <summary>
/// Example14.csと紐づいているクラス
/// Character6.csと紐づいているクラス
/// </summary> 
[CustomPropertyDrawer(typeof(Character6))]
public class CharacterDrawe1 : PropertyDrawer
{
	private Character6 character;

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		//元は1つのプロパティーであることを示すためにPropertyScopeで囲む
		using (new EditorGUI.PropertyScope(position, label, property))
		{
			//サムネの領域を確保するためにラベル領域の幅を小さくする
			EditorGUIUtility.labelWidth = 50;
			position.height = EditorGUIUtility.singleLineHeight;
			var halfWidth = position.width * 0.5f;

			//各プロパティーのRectを求める
			var iconRect = new Rect(position)
			{
				width = 64,
				height = 64
			};

			var nameRect = new Rect(position)
			{
				width = position.width - 64,
				x = position.x + 64
			};

			var hpRect = new Rect(nameRect)
			{
				y = nameRect.y + EditorGUIUtility.singleLineHeight + 2
			};

			var powerRect = new Rect(hpRect)
			{
				y = hpRect.y + EditorGUIUtility.singleLineHeight + 2
			};

			//各プロパティーのSerializedPropertyを求める
			var iconProperty = property.FindPropertyRelative("icon");
			var nameProperty = property.FindPropertyRelative("name");
			var hpProperty = property.FindPropertyRelative("hp");
			var powerProperty = property.FindPropertyRelative("power");

			//各プロパティーのGUIを描画
			iconProperty.objectReferenceValue = EditorGUI.ObjectField(iconRect, iconProperty.objectReferenceValue, typeof(Texture), false);

			nameProperty.stringValue = EditorGUI.TextField(nameRect, nameProperty.displayName, nameProperty.stringValue);

			EditorGUI.IntSlider(hpRect, hpProperty, 0, 100);
			EditorGUI.IntSlider(powerRect, powerProperty, 0, 10);
		}
	}
}
#endif
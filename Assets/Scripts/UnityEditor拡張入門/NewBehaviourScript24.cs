#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

/// <summary>
/// エディタウィンドウを作る為の金型
/// </summary>
public class NewBehaviourScript24 : EditorWindow
{
	[MenuItem("Kashiwabara/NewBehaviourScript24")]
	static void Open()
	{
		GetWindow<NewBehaviourScript24>();
	}

	public static Sprite SpriteField(Sprite sprite, params GUILayoutOption[] options)
	{
		// スプライトフィールドのラベルを表示
		EditorGUILayout.LabelField(", ", options);

		// ラベルの位置を取得
		var rect = GUILayoutUtility.GetLastRect();

		// スプライトフィールドを描画し、選択されたスプライトを返す
		return (Sprite)EditorGUI.ObjectField(rect, sprite, typeof(Sprite), allowSceneObjects: false);
	}
}
#endif
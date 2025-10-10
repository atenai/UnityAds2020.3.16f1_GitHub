#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

/// <summary>
/// 新しいAnimationClipアセットを作成する
/// </summary>
public class ExampleWindow46 : EditorWindow
{
	[MenuItem("Kashiwabara/Example46")]
	static void Open()
	{
		//まだアセットとして存在しないオブジェクトを作成
		var clip = new AnimationClip();

		//アセットとして保存
		//AssetDatabaseで扱うパスはUnityプロジェクトから相対パスで指定できる
		AssetDatabase.CreateAsset(clip, "Assets/Animation/New AnimationClip.anim");
	}
}
#endif
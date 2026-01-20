#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

/// <summary>
/// エディタウィンドウを作る為の金型
/// 最小限のエディター拡張コード
/// </summary>
public class NewEditorWindow : EditorWindow
{
	[MenuItem("Kashiwabara/NewEditorWindow")]
	static void Open()
	{
		GetWindow<NewEditorWindow>();
	}

	void OnGUI()
	{

	}
}
#endif
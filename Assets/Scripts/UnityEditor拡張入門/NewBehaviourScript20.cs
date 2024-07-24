#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

/// <summary>
/// エディタウィンドウを作る為の金型
/// </summary>
public class NewBehaviourScript20 : EditorWindow
{
	[MenuItem("Kashiwabara/NewBehaviourScript20")]
	static void Open()
	{
		GetWindow<NewBehaviourScript20>();
	}

	void OnGUI()
	{

	}
}
#endif
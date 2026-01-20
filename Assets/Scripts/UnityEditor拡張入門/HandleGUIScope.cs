#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class HandleGUIScope : GUI.Scope
{
	/// <summary>
	/// コンストラクタ
	/// </summary>
	public HandleGUIScope()
	{
		Handles.BeginGUI();
	}

	protected override void CloseScope()
	{
		Handles.EndGUI();
	}
}
#endif
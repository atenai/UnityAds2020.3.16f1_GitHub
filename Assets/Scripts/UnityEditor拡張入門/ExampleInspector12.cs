#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

/// <summary>
/// Example27.csと紐づいているクラス
/// </summary> 
[CustomEditor(typeof(Example27))]
public class ExampleInspecto12 : Editor
{
	Example27 component;

	void OnEnable()
	{
		//ここは様式美
		Tools.current = Tool.None;
		component = target as Example27;
		//ここは様式美
	}

	void OnSceneGUI()
	{
		Handles.BeginGUI();

		GUILayout.Button("Button", GUILayout.Width(50));

		Handles.EndGUI();
	}
}
#endif
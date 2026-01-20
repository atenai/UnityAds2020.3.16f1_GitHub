#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

/// <summary>
/// Example29.csと紐づいているクラス
/// </summary> 
[CustomEditor(typeof(Example29))]
public class ExampleInspecto14 : Editor
{
	Example29 component;

	int windowID = 1234;
	Rect windowRect;

	void OnEnable()
	{
		//ここは様式美
		Tools.current = Tool.None;
		component = target as Example29;
		//ここは様式美
	}

	void OnSceneGUI()
	{
		Handles.BeginGUI();

		windowRect = GUILayout.Window
		(
			windowID,
			windowRect,
			(id) =>
			{
				EditorGUILayout.LabelField("Label");
				EditorGUILayout.ToggleLeft("Toggle", false);
				GUILayout.Button("Button");
				GUI.DragWindow();

			},
			"Window",
			GUILayout.Width(100)
		);

		Handles.EndGUI();
	}
}
#endif
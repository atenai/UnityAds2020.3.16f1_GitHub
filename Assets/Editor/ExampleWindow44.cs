#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

/// <summary>
/// ModifierKeysChangedイベントのサンプル
/// </summary>
public class ExampleWindow44 : EditorWindow
{
	[MenuItem("Kashiwabara/Example44")]
	static void CheckModifierKeysChanged()
	{
		GetWindow<ExampleWindow44>();
	}

	void OnEnable()
	{
		EditorApplication.modifierKeysChanged += Repaint;
	}

	void OnGUI()
	{
		GUILayout.Label(Event.current.modifiers.ToString());
	}
}
#endif
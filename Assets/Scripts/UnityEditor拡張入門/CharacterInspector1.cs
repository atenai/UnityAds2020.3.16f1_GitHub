using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Character1))]
public class CharacterInspector1 : Editor
{
	SerializedProperty hpProperty;

	void OnEnable()
	{
		hpProperty = serializedObject.FindProperty("hp");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.IntSlider(hpProperty, 0, 100);

		serializedObject.ApplyModifiedProperties();
	}
}

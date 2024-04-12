using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CanEditMultipleObjects]
[CustomEditor(typeof(Character4))]
public class CharacterInspector4 : Editor
{
	SerializedProperty exampleProperty;

	void OnEnable()
	{
		exampleProperty = serializedObject.FindProperty("example3");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.PropertyField(exampleProperty);

		serializedObject.ApplyModifiedProperties();
	}
}

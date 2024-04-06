using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Character2))]
public class CharacterInspector2 : Editor
{
	Character2 character2;

	void OnEnable()
	{
		character2 = (Character2)target;
	}

	public override void OnInspectorGUI()
	{
		EditorGUI.BeginChangeCheck();

		var hp = EditorGUILayout.IntSlider("Hp", character2.hp, 0, 100);

		if (EditorGUI.EndChangeCheck() == true)
		{
			//変更前にUndoに登録
			Undo.RecordObject(character2, "Change hp");
			character2.hp = hp;
		}
	}
}

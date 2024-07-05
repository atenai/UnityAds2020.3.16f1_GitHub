#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CanEditMultipleObjects]
[CustomEditor(typeof(Character3))]
public class CharacterInspector3 : Editor
{
	Character3[] characters3;

	void OnEnable()
	{
		characters3 = targets.Cast<Character3>().ToArray();
	}

	public override void OnInspectorGUI()
	{
		EditorGUI.BeginChangeCheck();

		//異なる値が2以上であればtrue
		//Distinct()はLINQで重複した要素のみを削除する
		EditorGUI.showMixedValue = characters3.Select(x => x.hp).Distinct().Count() > 1;

		var hp = EditorGUILayout.IntSlider("Hp", characters3[0].hp, 0, 100);

		EditorGUI.showMixedValue = false;

		if (EditorGUI.EndChangeCheck())
		{
			//すべてのコンポーネントをUndoに登録
			Undo.RecordObjects(characters3, "Change hp");

			//すべてのコンポーネントに値を代入して更新
			foreach (var character3 in characters3)
			{
				character3.hp = hp;
			}
		}
	}
}
#endif
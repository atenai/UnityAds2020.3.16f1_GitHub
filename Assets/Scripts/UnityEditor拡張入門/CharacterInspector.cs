using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Character))]
public class CharacterInspector : Editor
{
	Character character = null;

	void OnEnable()
	{
		//Characterコンポーネントを取得
		character = (Character)target;
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();//元のGUIの要素をそのまま表示する

		//攻撃力の数値をラベルとして表示する（インスペクターに要素を追加する）
		EditorGUILayout.LabelField("攻撃力(エディタから追加)", character.攻撃力.ToString());
	}
}

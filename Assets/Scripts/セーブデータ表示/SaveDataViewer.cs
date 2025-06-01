using System;
using System.Reflection;
using UnityEngine;

public class SaveDataViewer : MonoBehaviour
{
	void Start()
	{
		SaveData saveData = new SaveData();
		Debug.Log("=== セーブデータの内容 ===");
		DisplayAllFields(saveData);
	}

	void DisplayAllFields(object obj, int indent = 0)
	{
		if (obj == null)
		{
			Debug.Log($"{new string(' ', indent)}null");
			return;
		}

		Type type = obj.GetType();

		// プリミティブ型、文字列、decimalはそのまま表示
		if (type.IsPrimitive || type == typeof(string) || type == typeof(decimal))
		{
			Debug.Log($"{new string(' ', indent)}{obj} (Type: {type.Name})");
			return;
		}

		// 配列やリストに対応したければここで処理を追加可能

		// フィールド取得（public + private）
		BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
		FieldInfo[] fields = type.GetFields(flags);

		foreach (FieldInfo field in fields)
		{
			object value = field.GetValue(obj);
			Type fieldType = field.FieldType;
			string indentStr = new string(' ', indent);

			if (fieldType.IsPrimitive || fieldType == typeof(string) || fieldType == typeof(decimal))
			{
				Debug.Log($"{indentStr}{field.Name} = {value} (Type: {fieldType.Name})");
			}
			else
			{
				Debug.Log($"{indentStr}{field.Name} (Type: {fieldType.Name}) →");
				DisplayAllFields(value, indent + 4);
			}
		}
	}
}

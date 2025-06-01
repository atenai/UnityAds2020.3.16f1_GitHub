using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveDataDisplayUI : MonoBehaviour
{
	[SerializeField] GameObject buttonPrefab; // Text付きボタンのプレハブ
	[SerializeField] Transform contentParent; // ScrollRectのContentに相当

	void Start()
	{
		SaveData data = new SaveData();
		DisplaySaveData(data);
	}

	void DisplaySaveData(object obj)
	{
		ClearButtons(); // 再表示用

		if (obj == null) return;

		GenerateButtonsRecursive(obj, 0);
	}

	void GenerateButtonsRecursive(object obj, int indent)
	{
		if (obj == null) return;

		Type type = obj.GetType();
		BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
		FieldInfo[] fields = type.GetFields(flags);

		foreach (FieldInfo field in fields)
		{
			object value = field.GetValue(obj);
			Type fieldType = field.FieldType;

			string indentStr = new string(' ', indent * 2); // インデント
			string text = $"{indentStr}{fieldType.Name} {field.Name} = {value}";

			CreateButton(text);

			// プリミティブ型や文字列でなければ再帰的に処理
			if (value != null && !fieldType.IsPrimitive && fieldType != typeof(string) && fieldType != typeof(decimal))
			{
				GenerateButtonsRecursive(value, indent + 1);
			}
		}
	}

	void CreateButton(string text)
	{
		GameObject buttonObj = Instantiate(buttonPrefab, contentParent);
		buttonObj.SetActive(true); // 必ず表示
		TMP_Text textComponent = buttonObj.GetComponentInChildren<TMP_Text>();
		if (textComponent != null)
		{
			textComponent.text = text;
		}
	}

	void ClearButtons()
	{
		foreach (Transform child in contentParent)
		{
			if (child != buttonPrefab.transform)
			{
				Destroy(child.gameObject);
			}
		}
	}
}

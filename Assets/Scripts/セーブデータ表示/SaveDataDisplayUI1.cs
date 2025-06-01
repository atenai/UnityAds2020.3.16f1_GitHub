using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveDataDisplayUI1 : MonoBehaviour
{
	[SerializeField] GameObject buttonPrefab;     // Text付きボタンのプレハブ
	[SerializeField] Transform contentParent;     // ScrollRectのContent
	private object rootData;                      // 元のセーブデータ

	void Start()
	{
		rootData = new SaveData();
		DisplaySaveData(rootData); // 初期表示
	}

	void DisplaySaveData(object obj)
	{
		ClearButtons();
		if (obj != null)
		{
			GenerateButtonsRecursive(obj, 0);
		}
	}

	void GenerateButtonsRecursive(object obj, int indent)
	{
		if (obj == null) return;

		Type type = obj.GetType();
		BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

		// Fields
		foreach (var field in type.GetFields(flags))
		{
			object value = field.GetValue(obj);
			string label = $"{new string(' ', indent * 2)}{field.FieldType.Name} {field.Name} = {value}";
			CreateButton(label, value);
		}

		// Properties
		foreach (var prop in type.GetProperties(flags))
		{
			// get可能、index無しプロパティのみ対象
			if (!prop.CanRead || prop.GetIndexParameters().Length > 0) continue;

			object value;
			try { value = prop.GetValue(obj); }
			catch { continue; }

			string label = $"{new string(' ', indent * 2)}{prop.PropertyType.Name} {prop.Name} = {value}";
			CreateButton(label, value);
		}
	}

	void CreateButton(string label, object value)
	{
		GameObject buttonObj = Instantiate(buttonPrefab, contentParent);
		buttonObj.SetActive(true);

		TMP_Text textComponent = buttonObj.GetComponentInChildren<TMP_Text>();
		if (textComponent != null)
		{
			textComponent.text = label;
		}

		Button btn = buttonObj.GetComponent<Button>();
		if (btn != null && value != null)
		{
			Type valType = value.GetType();
			if (!valType.IsPrimitive && valType != typeof(string) && valType != typeof(decimal))
			{
				// 押したらそのオブジェクトだけを再表示
				btn.onClick.AddListener(() => DisplaySaveData(value));
			}
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

	// 初期化ボタンなどから呼び出す用
	public void BackToRoot()
	{
		DisplaySaveData(rootData);
	}
}

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveDataDisplayUI2 : MonoBehaviour
{
	[SerializeField] GameObject buttonPrefab;
	[SerializeField] Transform contentParent;
	[SerializeField] Button backButton; // UIの「戻る」ボタン

	private Stack<object> historyStack = new Stack<object>(); // 戻る履歴
	private object currentObject; // 現在表示しているデータ

	void Start()
	{
		SaveData rootData = new SaveData();
		ShowObject(rootData, clearHistory: true);
		backButton.onClick.AddListener(GoBack);
	}

	void ShowObject(object obj, bool clearHistory = false)
	{
		if (obj == null) return;

		currentObject = obj;

		if (clearHistory)
		{
			historyStack.Clear();
		}

		UpdateUI(obj);
	}

	void UpdateUI(object obj)
	{
		ClearButtons();

		Type type = obj.GetType();
		BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

		foreach (var field in type.GetFields(flags))
		{
			object value = field.GetValue(obj);
			string label = $"{field.FieldType.Name} {field.Name} = {value}";
			CreateButton(label, value);
		}

		foreach (var prop in type.GetProperties(flags))
		{
			if (!prop.CanRead || prop.GetIndexParameters().Length > 0) continue;

			object value;
			try { value = prop.GetValue(obj); }
			catch { continue; }

			string label = $"{prop.PropertyType.Name} {prop.Name} = {value}";
			CreateButton(label, value);
		}

		// 「戻る」ボタンの表示切り替え
		backButton.gameObject.SetActive(historyStack.Count > 0);
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
				btn.onClick.AddListener(() =>
				{
					historyStack.Push(currentObject); // 履歴追加
					ShowObject(value);
				});
			}
		}
	}

	void GoBack()
	{
		if (historyStack.Count > 0)
		{
			object previous = historyStack.Pop();
			ShowObject(previous, clearHistory: false);
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

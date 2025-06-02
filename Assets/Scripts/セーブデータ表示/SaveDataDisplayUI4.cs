using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveDataDisplayUI4 : MonoBehaviour
{
	[SerializeField] GameObject buttonPrefab;
	[SerializeField] Transform contentParent;
	[SerializeField] Button backButton;

	private Stack<object> historyStack = new Stack<object>();
	private object currentObject;

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
			historyStack.Clear();

		UpdateUI(obj);
	}

	void UpdateUI(object obj)
	{
		ClearButtons();

		Type type = obj.GetType();
		BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

		// 🔽 Dictionary 対応（Keyのみ表示、押すと Value 展開）
		if (obj is IDictionary dictionary)
		{
			foreach (DictionaryEntry entry in dictionary)
			{
				string keyStr = entry.Key.ToString();
				object value = entry.Value;
				string label = $"Key: {keyStr} = Value";
				CreateButton(label, value); // key名でボタン作成、valueに移動
			}

			backButton.gameObject.SetActive(historyStack.Count > 0);
			return;
		}

		// 🔁 List/Array（前回の IsEnumerable 処理）
		if (IsEnumerable(obj))
		{
			int index = 0;
			foreach (var item in (IEnumerable)obj)
			{
				string label = $"[{index}] = {item}";
				CreateButton(label, item);
				index++;
			}

			backButton.gameObject.SetActive(historyStack.Count > 0);
			return;
		}

		// 通常のフィールド/プロパティ
		foreach (var field in type.GetFields(flags))
		{
			// 自動プロパティのバックフィールドを除外
			if (field.Name.Contains("k__BackingField")) continue;

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

		backButton.gameObject.SetActive(historyStack.Count > 0);
	}

	void CreateButton(string label, object value)
	{
		GameObject buttonObj = Instantiate(buttonPrefab, contentParent);
		buttonObj.SetActive(true);

		TMP_Text textComponent = buttonObj.GetComponentInChildren<TMP_Text>();
		if (textComponent != null)
			textComponent.text = label;

		Button btn = buttonObj.GetComponent<Button>();
		if (btn != null && value != null)
		{
			Type valType = value.GetType();
			if (!IsSimpleType(valType))
			{
				btn.onClick.AddListener(() =>
				{
					historyStack.Push(currentObject);
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
				Destroy(child.gameObject);
		}
	}

	bool IsSimpleType(Type type)
	{
		return type.IsPrimitive || type == typeof(string) || type == typeof(decimal);
	}

	bool IsEnumerable(object obj)
	{
		if (obj is string || obj == null) return false;
		return obj is IEnumerable && !(obj is IDictionary);
	}
}

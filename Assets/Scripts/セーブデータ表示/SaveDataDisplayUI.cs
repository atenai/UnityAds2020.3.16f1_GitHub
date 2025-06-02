using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// セーブデータ表示
/// 消すな！！
/// </summary>
public class SaveDataDisplayUI : MonoBehaviour
{
	[SerializeField] GameObject buttonPrefab;
	[SerializeField] Transform contentParent;
	[SerializeField] Button backButton;

	private Stack<object> historyStack = new Stack<object>();
	private object currentObject;

	void Start()
	{
		SaveData saveData = new SaveData();
		ShowObject(saveData, clearHistory: true);
		backButton.onClick.AddListener(GoBack);
	}

	void ShowObject(object obj, bool clearHistory = false)
	{
		if (obj == null)
		{
			return;
		}

		currentObject = obj;

		if (clearHistory == true)
		{
			historyStack.Clear();
		}

		UpdateUI(obj);
	}

	void UpdateUI(object currentObject)
	{
		ClearButtons();

		Type type = currentObject.GetType();
		BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

		// Dictionaryの処理
		if (currentObject is IDictionary dictionary)
		{
			foreach (DictionaryEntry entry in dictionary)
			{
				string keyStr = entry.Key.ToString();
				object value = entry.Value;
				string label = $"Key : {keyStr}";
				// key名で表示、押すとvalueに移動
				CreateButton(label, value);
			}

			backButton.gameObject.SetActive(0 < historyStack.Count);
			return;
		}

		// List・Arrayの処理
		if (IsEnumerable(currentObject) == true)
		{
			int index = 0;
			foreach (object item in (IEnumerable)currentObject)
			{
				string label = $"index : [{index}]";
				// index名で表示、押すとitemに移動
				CreateButton(label, item);
				index++;
			}

			backButton.gameObject.SetActive(0 < historyStack.Count);
			return;
		}

		// 通常の変数・プロパティの処理
		foreach (FieldInfo field in type.GetFields(flags))
		{
			// 自動実装プロパティはスキップ
			if (field.Name.Contains("k__BackingField") == true)
			{
				continue;
			}

			object value = field.GetValue(currentObject);
			string label = $"type : {field.FieldType.Name}, name : {field.Name}, value : {value}";
			CreateButton(label, value);
		}

		//自動実装プロパティの処理
		foreach (PropertyInfo prop in type.GetProperties(flags))
		{
			if (!prop.CanRead || 0 < prop.GetIndexParameters().Length)
			{
				continue;
			}

			object value;
			try
			{
				value = prop.GetValue(currentObject);
			}
			catch
			{
				continue;
			}

			string label = $"type : {prop.PropertyType.Name}, name : {prop.Name}, value : {value}";
			CreateButton(label, value);
		}

		backButton.gameObject.SetActive(0 < historyStack.Count);
	}

	//ボタン生成
	void CreateButton(string label, object value)
	{
		GameObject buttonObj = Instantiate(buttonPrefab, contentParent);

		TMP_Text textComponent = buttonObj.GetComponentInChildren<TMP_Text>();
		if (textComponent != null)
		{
			textComponent.text = label;
		}

		Button button = buttonObj.GetComponent<Button>();
		if (value != null)
		{
			Type valType = value.GetType();
			if (!IsSimpleType(valType))
			{
				button.onClick.AddListener(() =>
				{
					historyStack.Push(currentObject);
					ShowObject(value, clearHistory: false);
				});
			}
		}
	}

	/// <summary>
	/// 前の状態に戻る
	/// </summary>
	void GoBack()
	{
		if (0 < historyStack.Count)
		{
			object previous = historyStack.Pop();
			ShowObject(previous, clearHistory: false);
		}
	}

	/// <summary>
	/// ボタンを削除
	/// </summary>
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

	/// <summary>
	/// 通常の型（intやfloatなど） || string型 || decimal型　ならtrue
	/// 通常通りに使う基本的な型か？を調べる関数
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	bool IsSimpleType(Type type)
	{
		return type.IsPrimitive || type == typeof(string) || type == typeof(decimal);
	}

	/// <summary>
	/// 配列・リストか？を調べる関数
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	bool IsEnumerable(object obj)
	{
		//objがstring型 または objがnull ならfalse
		if (obj is string || obj == null)
		{
			return false;
		}
		//objがIEnumerable　かつ　objがIDictionaryでない ならtrue
		return obj is IEnumerable && !(obj is IDictionary);
	}
}

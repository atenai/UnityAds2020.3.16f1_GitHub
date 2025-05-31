using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class AllSaveDataView : MonoBehaviour
{
	void Start()
	{

	}

	void Update()
	{

	}

	public void All(object data)
	{
		Type type = data.GetType();
		FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
		foreach (FieldInfo fieldInfo in fieldInfos)
		{
			object value = fieldInfo.GetValue(data);
		}
	}
}

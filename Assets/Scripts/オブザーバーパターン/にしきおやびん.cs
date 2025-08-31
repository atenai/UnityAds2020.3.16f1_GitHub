using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class にしきおやびん : MonoBehaviour
{
	private static List<UnityAction> unityActionList = new List<UnityAction>();

	public static void AddListener(UnityAction unityAction)
	{
		unityActionList.Add(unityAction);
	}

	public static void RemoveListener(UnityAction unityAction)
	{
		unityActionList.Remove(unityAction);
	}

	public static void Invoke()
	{
		foreach (var unityAction in unityActionList)
		{
			if (unityAction != null)
			{
				unityAction.Invoke();
			}
		}
	}

	void Start()
	{
		AddListener(Talk);
	}

	void Talk()
	{
		Debug.Log("<color=red>やれ！</color>");
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Invoke();
		}
	}
}

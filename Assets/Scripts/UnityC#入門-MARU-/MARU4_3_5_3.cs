using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.UIElements;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

public class MARU4_3_5_3 : MonoBehaviour
{
	private async void Start()
	{
		Debug.Log("スタート関数開始");

		int a = await ABCAsync();
		Debug.Log($"a = {a}");

		string b = await DEFAsync();
		Debug.Log($"b = {b}");

		Debug.Log("スタート関数終了");
	}

	private async UniTask<int> ABCAsync()
	{
		Debug.Log("ABCAsync関数開始");

		Debug.Log("3秒待機開始");
		await UniTask.Delay(TimeSpan.FromSeconds(3));
		Debug.Log("3秒待機終了");

		Debug.Log("ABCAsync関数終了");

		return 100;
	}

	private async UniTask<string> DEFAsync()
	{
		Debug.Log("DEFAsync関数開始");

		Debug.Log("5秒待機開始");
		await UniTask.Delay(TimeSpan.FromSeconds(5));
		Debug.Log("5秒待機終了");

		Debug.Log("DEFAsync関数終了");

		return "ホンダ";
	}
}

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

public class MARU4_3_3_6 : MonoBehaviour
{
	private async void Start()
	{
		Debug.Log("スタート関数開始");

		//処理完了を待つ、返り値をresultXへ割り当てる
		int resultX = await GetSeverDataXAsync();

		//処理完了を待つ、返り値をresultYへ割り当てる
		string resultY = await GetSeverDataYAsync();

		Debug.Log($"ユーザーID:{resultX}");
		Debug.Log($"ユーザー名:{resultY}");

		Debug.Log("スタート関数終了");
	}

	private async Task<int> GetSeverDataXAsync()
	{
		Task<int> taskX = Task<int>.Run(GetSeverDataX);
		int resultX = await taskX;
		return resultX;
	}

	private async Task<string> GetSeverDataYAsync()
	{
		Task<string> taskY = Task<string>.Run(GetSeverDataY);
		string resultY = await taskY;
		return resultY;
	}

	private int GetSeverDataX()
	{
		Debug.Log("サーバーからユーザーID取得開始");

		Thread.Sleep(5000);//実際はここでサーバーから取得する

		Debug.Log("サーバーからユーザーID取得終了");

		return 12345;
	}

	private string GetSeverDataY()
	{
		Debug.Log("サーバーからユーザー名を取得開始");

		Thread.Sleep(5000);

		Debug.Log("サーバーからユーザー名の取得を終了");

		return "トヨタ";
	}
}

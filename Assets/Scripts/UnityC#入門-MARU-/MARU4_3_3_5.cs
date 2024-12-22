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

public class MARU4_3_3_5 : MonoBehaviour
{
	private async void Start()
	{
		Debug.Log("スタート関数開始");

		//タスクの作成
		Task<int> taskX = Task<int>.Run(GetSeverDataX);
		//処理完了を待つ、返り値をresultXへ割り当てる
		int resultX = await taskX;

		//タスクの作成
		Task<string> taskY = Task<string>.Run(GetSeverDataY);
		//処理完了を待つ、返り値をresultYへ割り当てる
		string resultY = await taskY;

		Debug.Log($"ユーザーID:{resultX}");
		Debug.Log($"ユーザー名:{resultY}");

		Debug.Log("スタート関数終了");
	}

	private int ABC()
	{
		Debug.Log("関数ABC処理開始");

		Thread.Sleep(5000);//5秒中断

		Debug.Log("関数ABC処理の終了");

		return 10;
	}

	private void DEF()
	{
		Debug.Log("関数DEF処理開始");

		Thread.Sleep(5000);//5秒中断

		Debug.Log("関数DEF処理の終了");
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

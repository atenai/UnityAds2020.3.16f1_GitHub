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

public class MARU4_3_3_1 : MonoBehaviour
{
	private int id;
	private string userName;

	private void Start()
	{
		Debug.Log("スタート関数開始");

		id = GetSeverDataX();
		Debug.Log($"ユーザーID:{id}");
		Debug.Log($"ユーザー名:{userName}");

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

		userName = GetSeverDataY();

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

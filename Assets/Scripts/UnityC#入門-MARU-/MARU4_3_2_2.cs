using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using System.Threading;
using System.Threading.Tasks;

public class MARU4_3_2_2 : MonoBehaviour
{
	private void Start()
	{
		//定義済みデリゲートの宣言
		//変数actionに関数ABCを登録
		Action action = ABC;

		//変数actionに関数DEFを追加
		action += DEF;

		Debug.Log("スタート関数開始");

		//括弧()内の返り値なしの関数を非同期で実行する
		Task.Run(action);

		Debug.Log("スタート関数終了");
	}

	private void Update()
	{
		// if (Input.GetKeyDown(KeyCode.Space) == true)
		// {
		// 	Debug.Log("スタート関数開始");
		// 	ABC();
		// 	Debug.Log("スタート関数終了");
		// }
	}

	private void ABC()
	{
		Debug.Log("関数ABC処理開始");

		Thread.Sleep(5000);//5秒中断

		Debug.Log("関数ABC処理の終了");
	}

	private void DEF()
	{
		Debug.Log("関数DEF処理開始");

		Thread.Sleep(5000);//5秒中断

		Debug.Log("関数DEF処理の終了");
	}
}

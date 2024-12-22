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

public class MARU4_3_3_3 : MonoBehaviour
{
	private async void Start()
	{
		Debug.Log("スタート関数開始");

		//括弧()内の返り値なしの関数を非同期で実行する
		await Task.Run(ABC);

		Debug.Log("スタート関数終了");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using System.Threading;
using System.Threading.Tasks;

public class MARU4_3_2_3 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		//int型を返すTask型の変数taskを宣言
		//関数ABCを非同期で実行する
		Task<int> task = Task<int>.Run(ABC);

		//Taskの完了まで待ち、結果を返す
		Debug.Log($"結果は{task.Result}");

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
}

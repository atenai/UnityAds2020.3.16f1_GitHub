using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using System.Threading;

public class MARU4_3_1_1 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		//Thread型の変数t1を宣言
		//変数t1へThread型のインスタンスを割り当て
		//括弧内に実行する関数を指定（ThreadStartデリゲート）
		Thread t1 = new Thread(ABC);

		//スレッドの開始
		t1.Start();

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
}

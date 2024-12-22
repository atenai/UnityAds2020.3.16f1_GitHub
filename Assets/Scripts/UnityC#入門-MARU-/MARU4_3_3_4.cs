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

public class MARU4_3_3_4 : MonoBehaviour
{
	private async void Start()
	{
		Debug.Log("スタート関数開始");

		await ABCAsync();

		Debug.Log("スタート関数終了");
	}

	//返り値が無い場合で処理を待ちたい場合、返り値はTask型を指定する
	//返り値をvoidにするとawaitによる処理待ちが負荷となる
	//returnで返り値を返す必要無し
	private async Task ABCAsync()
	{
		Task a = Task.Run(ABC);
		await a;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

public class MARU4_1_8_1 : MonoBehaviour
{
	private void Start()
	{
		//Action型の変数aaaを宣言
		Action aaa;

		//変数aaaへAction型と同じ仕様（返り値：なし　引数：なし）を割り当て
		aaa = ABC;

		//変数aaaへ割り当てた関数の実行
		aaa?.Invoke();
	}

	//条件式1　返り値：なし　引数：なし
	private void ABC()
	{
		Debug.Log("関数ABCを実行");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

public class MARU4_1_8_2 : MonoBehaviour
{
	private void Start()
	{
		//Action型の変数aaaを宣言 引数はint型とstring型
		Action<int, string> aaa;

		//変数aaaへAction型と同じ仕様（返り値：なし　引数：int型,string型）を割り当て
		aaa = ABC;

		//変数aaaへ割り当てた関数の実行
		aaa?.Invoke(5, "富士山");
	}

	//条件式1　返り値：なし　引数：int型,string型
	private void ABC(int number, string name)
	{
		Debug.Log("関数ABCを実行");
		Debug.Log($"引数は{number}と{name}です");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class MARU4_2_1_5 : MonoBehaviour
{
	private void Start()
	{
		//Func型 引数はint型 返り値はstring型の変数aaaを宣言
		//変数aaaへ関数ABCの割り当て
		Func<int, string> aaa = ABC;

		//変数aaaに割り当てた関数を実行
		Debug.Log(aaa?.Invoke(100));
	}

	private string ABC(int b)
	{
		return $"{b}の2倍は{2 * b}です";
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class MARU4_2_1_10 : MonoBehaviour
{
	private void Start()
	{
		//Func型 引数int型 返り値string型の変数aaaを宣言
		//変数aaaへ処理内容の割り当て
		Func<int, string> aaa = b => $"{b}の2倍は{2 * b}です";

		//変数aaaに割り当てた関数を実行
		Debug.Log(aaa?.Invoke(100));
	}
}

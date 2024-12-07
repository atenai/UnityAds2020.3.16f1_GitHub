using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

public class MARU4_1_9_1 : MonoBehaviour
{
	private void Start()
	{
		//Func型の変数aaaを宣言
		//引数はfloat型とstring型
		//返り値はint型
		Func<float, string, int> aaa;

		//変数aaaへFunc型と同じ仕様（返り値：int型　引数：float型,string型）を割り当て
		aaa = ABC;

		//変数aaaへ割り当てた関数の実行
		Debug.Log(aaa?.Invoke(5.0f, "富士山"));
	}

	//条件式1　返り値：int型　引数：float型,string型
	private int ABC(float number, string name)
	{
		Debug.Log("関数ABCを実行");
		Debug.Log($"引数は{number}と{name}です");

		return 10;
	}
}

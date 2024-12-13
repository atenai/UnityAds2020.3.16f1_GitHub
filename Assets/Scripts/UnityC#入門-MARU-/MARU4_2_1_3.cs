using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class MARU4_2_1_3 : MonoBehaviour
{
	private void Start()
	{
		//UnityAction型 引数はint型の変数aaaを宣言
		//変数aaaへ関数ABCの割り当て
		UnityAction<int> aaa = ABC;

		//変数aaaに割り当てた関数を実行
		aaa?.Invoke(100);
	}

	private void ABC(int b)
	{
		Debug.Log($"引数は{b}です");
	}
}

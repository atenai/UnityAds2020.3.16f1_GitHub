using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class MARU4_2_1_4 : MonoBehaviour
{
	private void Start()
	{
		//UnityAction型 引数はint型の変数aaaを宣言
		//変数aaaへ匿名メソッドの割り当て
		UnityAction<int> aaa = delegate (int b)
		{
			Debug.Log($"引数は{b}です");
		};

		//変数aaaに割り当てた関数を実行
		aaa?.Invoke(100);
	}

	private void ABC(int b)
	{
		Debug.Log($"引数は{b}です");
	}
}

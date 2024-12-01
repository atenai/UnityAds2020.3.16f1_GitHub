using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

public class MARU4_1_7_1 : MonoBehaviour
{
	private void Start()
	{
		//Predicate型の変数aaaを宣言
		Predicate<int> aaa;

		//変数aaaへPredicate型と同じ仕様（返り値：bool型　引数：int型）を割り当て
		aaa = ABC;

		//Check関数呼び出し　Predicate型とint型を引数として渡す
		Check(aaa, 2);
		Check(aaa, 3);

		//変数aaaへPredicate型と同じ仕様（返り値：bool型　引数：int型）を割り当て
		aaa = DEF;

		//Check関数呼び出し　Predicate型とint型を引数として渡す
		Check(aaa, 3);
		Check(aaa, 6);
	}

	//条件式1　返り値：bool型　引数：int型
	private bool ABC(int aaa)
	{
		return aaa == 3;
	}

	//条件式2　返り値：bool型　引数：int型
	private bool DEF(int ddd)
	{
		return 5 <= ddd;
	}

	private void Check(Predicate<int> predicate, int number)
	{
		if ((bool)predicate?.Invoke(number) == true)
		{
			Debug.Log($"引数は{number}。確認OK");
		}
	}
}

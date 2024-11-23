using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MARU4_1_3_1 : MonoBehaviour
{
	//デリゲートの定義 返り値:bool型 引数:int型
	public delegate bool TestX(int number);

	private void Start()
	{
		//TestX型の変数testXを宣言
		TestX testX;

		//変数testXへ同じ仕様の関数（返り値:bool型 引数:int型）を割り当て
		testX = ABC;

		//条件式を指定して呼び出し　TestX型とint型を引数として渡す
		Check(testX, 1);
		Check(testX, 3);

		//変数testXへ同じ仕様の関数（返り値:bool型 引数:int型）を割り当て
		testX = DEF;

		//条件式を指定して呼び出し　TestX型とint型を引数として渡す
		Check(testX, 2);
		Check(testX, 5);
	}

	/// <summary>
	/// 条件式１　返り値：bool型　引数：int型
	/// </summary>
	private bool ABC(int aaa)
	{
		return aaa == 3;
	}

	/// <summary>
	/// 条件式２　返り値：bool型　引数：int型
	/// </summary>
	private bool DEF(int ddd)
	{
		return 5 <= ddd;
	}

	//条件式を差し替えたい関数
	private void Check(TestX testX, int number)
	{
		Debug.Log(number);
		Debug.Log(testX.Invoke(number));

		//if (testX.Invoke(number) == true)
		if ((bool)testX?.Invoke(number) == true)//nullチェック版
		{
			Debug.Log($"引数{number}確認OK");
		}
	}
}

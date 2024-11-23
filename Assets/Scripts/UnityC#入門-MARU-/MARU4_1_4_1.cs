using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MARU4_1_4_1 : MonoBehaviour
{
	//デリゲートの定義 返り値:なし型 引数:なし型
	public delegate void TestX();

	private void Start()
	{
		//TestX型の変数testXを宣言
		TestX testX;

		//変数testXへ同じ仕様の関数（返り値:なし 引数:なし）を割り当て
		testX = ABC;

		//条件式を指定して呼び出し　TestX型を引数として渡す
		GameStart(testX);
		Debug.Log("--------------------");

		//変数testXへ同じ仕様の関数（返り値:なし 引数:なし）を割り当て
		testX = DEF;

		//条件式を指定して呼び出し　TestX型を引数として渡す
		GameStart(testX);
		Debug.Log("--------------------");

		testX = ABC;
		testX = testX + DEF;
		GameStart(testX);
		Debug.Log("--------------------");

		testX = DEF;
		testX += ABC;
		testX += DEF;
		GameStart(testX);
		Debug.Log("--------------------");
	}

	/// <summary>
	/// 条件式１　返り値：なし　引数：なし
	/// </summary>
	private void ABC()
	{
		Debug.Log("関数ABCを実行");
	}

	/// <summary>
	/// 条件式２　返り値：なし　引数：なし
	/// </summary>
	private void DEF()
	{
		Debug.Log("関数DEFを実行");
	}

	private void GameStart(TestX testX)
	{
		testX?.Invoke();
	}
}

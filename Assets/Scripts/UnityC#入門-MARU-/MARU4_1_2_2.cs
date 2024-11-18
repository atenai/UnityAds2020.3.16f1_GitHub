using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MARU4_1_2_2 : MonoBehaviour
{
	//デリゲートの定義 返り値:bool型 引数:int型
	public delegate bool TestX(int number);

	private void Start()
	{
		//TestX型の変数testXを宣言
		TestX testX;

		//変数testXへ同じ仕様の関数（返り値:なし 引数:int型, string型）を割り当て
		testX = ABC;
		//testX = null;

		//変数testXへ割り当てた関数の実行 パターン2
		//null条件演算子?.を使用しnullチェック実施
		Debug.Log(testX?.Invoke(2));

		Debug.Log(testX?.Invoke(3));
	}

	private bool ABC(int aaa)
	{
		return aaa == 3;
	}
}

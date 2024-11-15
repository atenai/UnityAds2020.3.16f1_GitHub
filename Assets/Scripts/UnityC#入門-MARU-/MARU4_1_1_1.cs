using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MARU4_1_1_1 : MonoBehaviour
{
	//デリゲートの定義 返り値:なし 引数:int型
	public delegate void TestX(int number);

	private void Start()
	{
		//TestX型の変数testXを宣言
		TestX testX;

		//変数testXへ同じ仕様の関数（返り値:なし 引数:int型）を割り当て
		testX = ABC;

		//(参考)古い書き方 関数の割り当て
		//testX = new TestX(ABC);

		//変数testXへ割り当てた関数の実行 パターン1
		testX(1);

		//変数testXへ割り当てた関数の実行 パターン2
		testX.Invoke(2);
	}

	private void ABC(int aaa)
	{
		Debug.Log($"関数ABCが呼ばれました。引数は{aaa}です。");
	}
}

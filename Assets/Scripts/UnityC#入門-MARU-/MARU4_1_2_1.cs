using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MARU4_1_2_1 : MonoBehaviour
{
	//デリゲートの定義 返り値:なし 引数:int型とstring型
	public delegate void TestX(int number, string name);

	private void Start()
	{
		//TestX型の変数testXを宣言
		TestX testX;

		//変数testXへ同じ仕様の関数（返り値:なし 引数:int型, string型）を割り当て
		testX = ABC;
		//testX = null;

		//変数testXへ割り当てた関数の実行 パターン2
		//null条件演算子?.を使用しnullチェック実施
		testX?.Invoke(2, "柏原");
	}

	private void ABC(int aaa, string bbb)
	{
		Debug.Log($"関数ABCが呼ばれました。引数は{aaa}と{bbb}です。");
	}
}

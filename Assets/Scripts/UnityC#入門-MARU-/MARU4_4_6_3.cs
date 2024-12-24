using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.UIElements;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using System.Linq;

public class MARU4_4_6_3 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		List<int> aaa = new List<int>() { 0, 20, 50, 100, 500, 1000, 10, 50 };

		//関数ABCを渡すと関数ABCの引数に1要素ずつ入って条件式で評価される
		//その判定結果からAny関数の返り値が決定する
		bool resultA = aaa.Any(ABC);

		Debug.Log(resultA);

		Debug.Log("スタート関数終了");
	}

	//bool型を返す関数ABC
	//引数の変数名xは別の好きな名前でも問題ありません
	private bool ABC(int x)
	{
		return 900 < x;
	}
}

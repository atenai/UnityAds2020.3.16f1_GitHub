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

public class MARU4_4_3_1 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		//Dictionary型でstring型をキーとしてint型の値を扱う変数aを宣言
		Dictionary<string, int> a;

		//Dictionary型（キーはstring型、値はint型）のインスタンスを作成し変数aへ割り当て
		a = new Dictionary<string, int>();

		//要素の追加
		a.Add("国語テストの点数", 80);
		a.Add("算数テストの点数", 100);
		a.Add("理科テストの点数", 90);

		//キーから値を取得
		Debug.Log(a["算数テストの点数"]);

		//要素の削除
		a.Remove("国語テストの点数");

		Debug.Log("スタート関数終了");
	}
}

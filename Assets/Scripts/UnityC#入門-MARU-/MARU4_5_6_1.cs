using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using System.Linq;

public class MARU4_5_6_1 : MonoBehaviour
{
	private void Start()
	{
		UnityEngine.Debug.Log("スタート関数開始");

		Debug.Log(ABC<int>(2, 3));
		Debug.Log(ABC<string>("aaa", "bbb"));
		Debug.Log(ABC<float>(10.0f, 100.0f));

		UnityEngine.Debug.Log("スタート関数終了");
	}

	//引数aとbのデータを入れ替える関数
	public T ABC<T>(T a, T b)
	{
		T c = a;
		a = b;
		b = c;

		return a;
	}
}

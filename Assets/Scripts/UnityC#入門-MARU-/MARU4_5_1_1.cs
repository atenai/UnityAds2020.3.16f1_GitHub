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
using BehaviorDesigner.Runtime.Tasks.Unity.UnityPlayerPrefs;
using System.Diagnostics;

public class MARU4_5_1_1 : MonoBehaviour
{
	private void Start()
	{
		UnityEngine.Debug.Log("スタート関数開始");

		//Stopwatch型の変数aを宣言
		//作成したStopwatch型のインスタンスを変数aに割り当て
		Stopwatch a = new Stopwatch();

		//計測開始
		a.Start();

		int number = 0;

		for (int i = 0; i < 100000000; i++)
		{
			number++;
		}

		//計測終了
		a.Stop();

		//名前空間System.Diagnosticsと
		//名前空間UnityEngineの両方にDebug型が定義されている
		//名前空間UnityEngineに定義されているDebug型を使用したいため
		//UnityEngineを先頭に書き、UnityEngineのDebug型の使用を明示する
		UnityEngine.Debug.Log(a.Elapsed);
		UnityEngine.Debug.Log(a.ElapsedMilliseconds);

		UnityEngine.Debug.Log("スタート関数終了");
	}
}

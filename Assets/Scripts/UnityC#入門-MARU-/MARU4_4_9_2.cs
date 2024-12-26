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

public class MARU4_4_9_2 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		int a = 0;
		Debug.Log($"① aの値は{a}です。");

		//引数に変数aを渡し実行
		RefTest(ref a);

		Debug.Log($"③ aの値は{a}です。");

		Debug.Log("スタート関数終了");
	}

	//値型の参照渡し
	private void RefTest(ref int abc)
	{
		Debug.Log($"? abcの値は{abc}です。");
		abc = 100;
		Debug.Log($"② abcの値は{abc}です。");
	}
}

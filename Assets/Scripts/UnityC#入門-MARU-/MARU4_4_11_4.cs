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

public class MARU4_4_11_4 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		int a = 1;
		int b = 100;

		Debug.Log($"aの値は{a} bの値は{b}");

		//Tupleを使用した値の入れ替え
		(a, b) = (b, a);

		Debug.Log($"aの値は{a} bの値は{b}");

		Debug.Log("スタート関数終了");
	}
}

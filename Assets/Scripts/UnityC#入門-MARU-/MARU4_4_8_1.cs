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

public class MARU4_4_8_1 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		int a = 0;
		int b = 100;

		a = b;
		a = 1000;

		Debug.Log($"aの値は{a}です。");
		Debug.Log($"bの値は{b}です。");

		Debug.Log("スタート関数終了");
	}
}

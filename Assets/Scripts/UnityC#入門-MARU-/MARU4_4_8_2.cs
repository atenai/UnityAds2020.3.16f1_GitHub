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

public class MARU4_4_8_2 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		int[] a = new int[]{0,1,2};
		int[] b = new int[]{10,100,1000};

		a = b;
		a[0] = 999;

		Debug.Log($"aの値は{a[0]},{a[1]},{a[2]}です。");
		Debug.Log($"bの値は{b[0]},{b[1]},{b[2]}です。");

		Debug.Log("スタート関数終了");
	}
}

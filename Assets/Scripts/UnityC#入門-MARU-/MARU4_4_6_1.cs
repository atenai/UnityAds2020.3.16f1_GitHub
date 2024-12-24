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

public class MARU4_4_6_1 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		List<int> aaa = new List<int>() { 0, 20, 50, 100, 500, 1000, 10, 50 };

		int resultA = aaa.Max();

		Debug.Log(resultA);

		Debug.Log("スタート関数終了");
	}
}

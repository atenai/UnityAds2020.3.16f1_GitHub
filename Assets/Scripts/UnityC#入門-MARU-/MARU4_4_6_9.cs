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

public class MARU4_4_6_9 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		List<int> aaa = new List<int>() { 0, 20, 50, 100, 500, 1000, 10, 50 };

		IEnumerable<int> resultA = aaa.Where(x => 70 < x);
		IEnumerable resultB = resultA.Skip(2);

		foreach (int zzz in resultB)
		{
			Debug.Log(zzz);
		}

		Debug.Log("スタート関数終了");
	}

}

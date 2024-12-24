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

public class MARU4_4_2_2 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		MARU4_4_2_1.TestC();

		Debug.Log("スタート関数終了");
	}
}

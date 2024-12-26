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

public class MARU4_4_11_1 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		//変数に関数の結果を入れる
		(int xx, bool yy) abcResult = ABC();

		Debug.Log(abcResult.xx);
		Debug.Log(abcResult.yy);

		Debug.Log("スタート関数終了");
	}

	private (int a, bool b) ABC()
	{
		return (1, true);
	}
}

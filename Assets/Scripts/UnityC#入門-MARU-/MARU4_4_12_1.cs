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

public class MARU4_4_12_1 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		GameObject a = null;

		//変数aには何も入っていないためエラー発生
		a.SetActive(false);

		Debug.Log("スタート関数終了");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using System.Linq;

public class MARU4_5_5_1 : MonoBehaviour
{
	//GameObject型の変数TestObjectを宣言
	//カプセルオブジェクトをインスペクターから割り当て
	public GameObject TestObject;

	private void Start()
	{
		UnityEngine.Debug.Log("スタート関数開始");

		UnityEngine.Debug.Log("スタート関数終了");
	}

	private void FixedUpdate()
	{
		TestObject.transform.Rotate(0.0f, 1.0f, 0.0f, Space.World);
	}
}

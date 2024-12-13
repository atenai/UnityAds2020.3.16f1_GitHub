using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class MARU4_2_1_1 : MonoBehaviour
{
	private void Start()
	{
		//UnityAction型の変数aaaを宣言
		//変数aaaへ関数ABCを割り当て
		UnityAction aaa = ABC;

		//変数aaaに割り当てた関数を実行
		aaa?.Invoke();
	}

	private void ABC()
	{
		Debug.Log("関数が呼ばれました");
	}
}

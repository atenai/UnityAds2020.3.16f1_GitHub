using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class MARU4_2_1_7 : MonoBehaviour
{
	private void Start()
	{
		//UnityAction型の変数aaaを宣言
		//変数aaaへ処理内容の割り当て
		UnityAction aaa = () => Debug.Log("関数が呼ばれました");

		//変数aaaに割り当てた関数を実行
		aaa?.Invoke();
	}
}

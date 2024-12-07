using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class MARU4_1_10_1 : MonoBehaviour
{
	private void Start()
	{
		//UnityAction型の変数aaaを宣言
		//引数はGameObject型
		UnityAction<GameObject> aaa;

		//変数aaaへUnityAction型と同じ仕様
		//（返り値：なし　引数：GameObject型）を割り当て
		aaa = ABC;

		//変数aaaへ割り当てた関数の実行
		aaa?.Invoke(this.gameObject);
	}

	//条件式1　返り値：なし　引数：GameObject型
	private void ABC(GameObject gameObject)
	{
		Debug.Log("関数ABCを実行");
		Debug.Log($"GameObject名は{gameObject.name}です");
	}
}

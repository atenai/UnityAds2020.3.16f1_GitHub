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

public class MARU4_3_5_5 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		StartCoroutine(ABC());

		Debug.Log("ゲームオブジェクト削除");
		Destroy(this.gameObject);

		Debug.Log("スタート関数終了");
	}

	private IEnumerator ABC()
	{
		Debug.Log("ABC関数開始");

		Debug.Log("5秒待機開始");
		yield return new WaitForSeconds(5f);
		Debug.Log("5秒待機終了");

		Debug.Log("ABC関数終了");
	}
}

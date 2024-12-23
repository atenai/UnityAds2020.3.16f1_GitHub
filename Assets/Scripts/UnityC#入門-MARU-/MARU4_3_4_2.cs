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

public class MARU4_3_4_2 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		StartCoroutine(XYZ());

		Debug.Log("スタート関数終了");
	}

	private IEnumerator XYZ()
	{
		yield return StartCoroutine(ABC());
		yield return StartCoroutine(DEF());
	}

	private IEnumerator ABC()
	{
		Debug.Log("ABC関数開始");

		Debug.Log("3秒待機開始");
		yield return new WaitForSeconds(3f);
		Debug.Log("3秒待機終了");

		Debug.Log("5秒待機開始");
		yield return new WaitForSeconds(5f);
		Debug.Log("5秒待機終了");

		Debug.Log("ABC関数終了");
	}

	private IEnumerator DEF()
	{
		Debug.Log("DEF関数開始");

		Debug.Log("5秒待機開始");
		yield return new WaitForSeconds(5f);
		Debug.Log("5秒待機終了");

		Debug.Log("DEF関数終了");
	}
}

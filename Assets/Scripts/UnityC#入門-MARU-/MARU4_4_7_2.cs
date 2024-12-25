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

public class MARU4_4_7_2 : MonoBehaviour
{
	//MARU4_4_7_1型の変数saveAを宣言
	private MARU4_4_7_1 saveA;

	//string型の変数jsonを宣言
	private string json;

	private void Start()
	{
		Debug.Log("スタート関数開始");

		//SaveAのインスタンスを生成し変数saveAへ割り当て
		saveA = new MARU4_4_7_1();

		//JsonUtilityクラスのToJson関数を使用しsaveAをJSON化
		json = JsonUtility.ToJson(saveA);

		Debug.Log("JSONデータ=" + json);

		Debug.Log("スタート関数終了");
	}

}

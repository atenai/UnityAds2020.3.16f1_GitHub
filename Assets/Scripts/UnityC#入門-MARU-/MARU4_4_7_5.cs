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

public class MARU4_4_7_5 : MonoBehaviour
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

		//データ変更
		saveA.a = 100000;
		saveA.b = 100000.5f;
		saveA.c = "テスト";

		//関数Save()の呼び出し
		Save();

		//関数Load()の呼び出し
		saveA = Load();
		Debug.Log("a=" + saveA.a);
		Debug.Log("b=" + saveA.b);
		Debug.Log("c=" + saveA.c);

		Debug.Log("スタート関数終了");
	}

	private void Save()
	{
		//JsonUtilityクラスのToJson関数を使用しsaveAをJSON化
		json = JsonUtility.ToJson(saveA);

		Debug.Log("JSONデータ=" + json);

		//変数jsonをセーブ
		PlayerPrefs.SetString("セーブキー", json);

		Debug.Log("セーブ実行終了");
	}

	private MARU4_4_7_1 Load()
	{
		//セーブデータをロード
		json = PlayerPrefs.GetString("セーブキー");
		Debug.Log("ロードしたデータ=" + json);

		return JsonUtility.FromJson<MARU4_4_7_1>(json);
	}
}

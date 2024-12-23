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

public class MARU4_3_5_7 : MonoBehaviour
{
	private async void Start()
	{
		Debug.Log("スタート関数開始");

		//CancellationTokenSource型の変数tokenSourceを宣言
		//変数tokenSourceへCancellationTokenSourceのインスタンスを割り当て
		CancellationTokenSource tokenSource = new CancellationTokenSource();

		//CancellationToken型の変数tokenAを宣言
		//変数tokenAへ　変数tokenSourceが持つTokenの情報を割り当て
		CancellationToken tokenA = tokenSource.Token;

		//UniTask　引数でtokenAの情報を渡す
		ABCAsync(tokenA);

		//キャンセル処理実行
		tokenSource.Cancel();

		Debug.Log("ゲームオブジェクト削除");
		Destroy(this.gameObject);

		Debug.Log("スタート関数終了");
	}

	//引数にCancellationToken型の変数tokenXを宣言
	private async UniTask ABCAsync(CancellationToken tokenX)
	{
		Debug.Log("ABCAsync関数開始");

		Debug.Log("5秒待機開始");

		//UniTaskの関数の引数にcancellationTokenの情報を渡しておく
		//cancellationTokenは任意の引数となっている。その為
		//名前付き引数にて　cancellationToken:変数名　と書き、情報を渡す
		await UniTask.Delay(TimeSpan.FromSeconds(5), cancellationToken: tokenX);

		Debug.Log("5秒待機終了");

		Debug.Log("ABCAsync関数終了");
	}
}

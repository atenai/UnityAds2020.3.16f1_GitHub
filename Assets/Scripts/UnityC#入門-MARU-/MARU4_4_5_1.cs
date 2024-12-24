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

public class MARU4_4_5_1 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		//string型の多次元配列(二次元)　変数aを宣言
		string[,] a;

		//一次元目の要素数3　二次元目の要素数4
		a = new string[3, 4];

		//各要素にデータを割り当て
		a[0, 0] = "イチロー";
		a[0, 1] = "大谷";
		a[0, 2] = "松井";
		a[0, 3] = "王";
		a[1, 0] = "本田";
		a[1, 1] = "長友";
		a[1, 2] = "長谷部";
		a[1, 3] = "中村";
		a[3, 0] = "福原";
		a[3, 1] = "水谷";
		a[3, 2] = "伊藤";
		a[3, 3] = "張本";

		Debug.Log("スタート関数終了");
	}
}

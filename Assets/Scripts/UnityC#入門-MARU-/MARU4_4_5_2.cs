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

public class MARU4_4_5_2 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		//string型の多次元配列(二次元)　変数aを宣言
		string[,] a;

		//一次元目の要素数3　二次元目の要素数4
		a = new string[3, 4]{
			{ "イチロー","大谷","松井","王"},
			{ "本田", "長友","長谷部","中村"},
			{ "福原", "水谷","伊藤","張本"},
		};

		//一次元目の要素数の取得
		Debug.Log(a.GetLength(0));

		//二次元目の要素数の取得
		Debug.Log(a.GetLength(1));

		//データの取り出し
		for (int i = 0; i < a.GetLength(0); i++)
		{
			for (int j = 0; j < a.GetLength(1); j++)
			{
				Debug.Log($"[{i}][{j}]={a[i, j]}");
			}
		}

		Debug.Log("スタート関数終了");
	}
}

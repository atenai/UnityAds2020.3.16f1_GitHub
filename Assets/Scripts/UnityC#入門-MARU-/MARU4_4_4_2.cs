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

public class MARU4_4_4_2 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		//string型のジャグ配列　変数aを宣言
		string[][] a;

		//一次配列の要素数の決定
		a = new string[3][];

		//二次配列の要素数の決定
		a[0] = new string[] { "イチロー", "大谷", "松井", "王", "田中" };
		a[1] = new string[] { "本田", "長友", "長谷部" };
		a[2] = new string[] { "福原", "水谷", "伊藤", "張本" };

		//データの取り出し
		for (int i = 0; i < a.Length; i++)
		{
			for (int j = 0; j < a[i].Length; j++)
			{
				Debug.Log($"[{i}][{j}]={a[i][j]}");
			}
		}

		Debug.Log("スタート関数終了");
	}
}

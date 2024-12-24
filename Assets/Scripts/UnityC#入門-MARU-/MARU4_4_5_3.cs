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

public class MARU4_4_5_3 : MonoBehaviour
{
	//Listの中にListを入れる
	public List<List<int>> Test_List = new List<List<int>>()
	{
		//Listの中にListを追加して初期化
		new List<int>(),
		new List<int>(),
		new List<int>(),
	};


	private void Start()
	{
		Debug.Log("スタート関数開始");


		Debug.Log("スタート関数終了");
	}
}

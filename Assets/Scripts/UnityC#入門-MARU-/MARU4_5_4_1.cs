using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using System.Linq;

public class MARU4_5_4_1 : MonoBehaviour
{
	//Image型の変数imageを宣言
	//インスペクターから対象のオブジェクトを割り当てて下さい。
	public Image image;

	private void Start()
	{
		UnityEngine.Debug.Log("スタート関数開始");

		//Resourcesフォルダの画像を
		//変数imageが持つSpriteプロパティへ割り当て
		image.sprite = Resources.Load<Sprite>("YK");

		UnityEngine.Debug.Log("スタート関数終了");
	}
}

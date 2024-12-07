using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class MARU4_1_11_3 : MonoBehaviour
{
	public MARU4_1_11_1 jump;

	public void JumpEventB()
	{
		Debug.Log("ジャンプイベントB");
	}

	public void JumpEventC()
	{
		Debug.Log("ジャンプイベントC");
	}

	private void Start()
	{
		//関数の追加
		jump.OnJumped.AddListener(JumpEventB);
		jump.OnJumped.AddListener(JumpEventC);

		//関数の削除
		jump.OnJumped.RemoveListener(JumpEventB);

		//関数の代入
		//jump.OnJumped = new UnityEvent();

		//関数の実行
		//jump.OnJumped?.Invoke();
	}
}

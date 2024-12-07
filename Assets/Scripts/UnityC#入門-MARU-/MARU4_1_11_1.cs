using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class MARU4_1_11_1 : MonoBehaviour
{
	//UnityEvent型の変数OnJumpedを宣言
	public UnityEvent OnJumped;

	private void Update()
	{
		//スペースキーを押した時の処理
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//UnityEvent型の変数OnJumpedに登録されている処理を実行
			OnJumped?.Invoke();

			Debug.Log("スペースキーが押されました");
		}
	}
}

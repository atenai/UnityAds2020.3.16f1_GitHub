using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MARU4_1_5_1 : MonoBehaviour
{
	//デリゲートの定義 返り値:なし型 引数:なし型
	public delegate void JumpHandler();

	//JumpHandler型の変数OnJumpedを宣言
	public event JumpHandler OnJumped;

	private void Start()
	{

	}

	private void Update()
	{
		//スペースキーを押した時の処理
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//JumpHandler型の変数OnJumpedに登録されている処理を実行
			OnJumped?.Invoke();

			Debug.Log("スペースキーが押されました");
		}
	}
}

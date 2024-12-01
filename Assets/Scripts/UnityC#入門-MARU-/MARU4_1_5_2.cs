using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MARU4_1_5_2 : MonoBehaviour
{
	//インスペクターからスクリプトMARU4_1_5_1が割りついているコンポーネントを取得します。
	public MARU4_1_5_1 jump;

	private void Start()
	{
		//関数の追加
		jump.OnJumped += JumpEventA;
		jump.OnJumped += JumpEventB;

		//関数の削除
		jump.OnJumped -= JumpEventA;

		//関数の代入
		//jump.OnJumped = JumpEventA;

		//関数の実行
		//jump.OnJumped?.Invoke();
	}

	private void JumpEventA()
	{
		Debug.Log("ジャンプイベントA");
	}

	private void JumpEventB()
	{
		Debug.Log("ジャンプイベントB");
	}
}

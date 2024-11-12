using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MARU3_3_3_4 : MonoBehaviour
{
	private void Start()
	{
		//MARU3_3_3_1インターフェースの型の変数aを宣言
		MARU3_3_3_1 a;

		//MARU3_3_3_2のインスタンスを生成し変数aへ割り当て
		a = new MARU3_3_3_2();
		a.Damage();

		//MARU3_3_3_3のインスタンスを生成し変数aへ割り当て
		a = new MARU3_3_3_3();
		a.Damage();
	}
}

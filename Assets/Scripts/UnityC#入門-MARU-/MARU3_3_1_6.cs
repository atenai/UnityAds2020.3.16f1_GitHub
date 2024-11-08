using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Assertions.Must;//Text型が含まれている名前空間を追加

public sealed class MARU3_3_1_6 : MonoBehaviour
{
	void Start()
	{
		//MARU3_3_1_1型の変数aを宣言
		MARU3_3_1_1 a;

		//変数aへMARU3_3_1_2型のインスタンスを割り当て
		a = new MARU3_3_1_2();
		a.Attack();
		a.Magic();

		//変数aへMARU3_3_1_4型のインスタンスを割り当て
		a = new MARU3_3_1_4();
		a.Attack();
		a.Magic();

		//変数aへMARU3_3_1_5型のインスタンスを割り当て
		a = new MARU3_3_1_5();
		a.Attack();
		a.Magic();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Assertions.Must;//Text型が含まれている名前空間を追加

public sealed class MARU3_3_1_3 : MonoBehaviour
{
	void Start()
	{
		//MARU3_3_1_1型のインスタンスを作成し、MARU3_3_1_1型の変数aへ割り当て
		MARU3_3_1_1 a = new MARU3_3_1_1();
		a.Attack();
		a.Magic();

		//MARU3_3_1_2型のインスタンスを作成し、MARU3_3_1_2型の変数bへ割り当て
		MARU3_3_1_2 b = new MARU3_3_1_2();
		b.Attack();
		b.Magic();

		//MARU3_3_1_2型のインスタンスを作成し、MARU3_3_1_1型の変数cへ割り当て
		MARU3_3_1_1 c = new MARU3_3_1_2();
		c.Attack();
		c.Magic();
	}
}

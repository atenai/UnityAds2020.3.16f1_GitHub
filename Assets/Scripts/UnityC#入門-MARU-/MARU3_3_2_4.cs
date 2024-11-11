using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public sealed class MARU3_3_2_4 : MonoBehaviour
{
	private void Start()
	{
		//MARU3_3_2_1型の変数aを宣言
		MARU3_3_2_1 a;

		//変数aへMARU3_3_2_2型のインスタンスを割り当て
		a = new MARU3_3_2_2();
		a.SkillAttack();

		//変数aへMARU3_3_2_3型のインスタンスを割り当て
		a = new MARU3_3_2_3();
		a.SkillAttack();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public abstract class MARU3_3_2_1
{
	//抽象関数
	public abstract void SkillAttack();

	//通常の関数を定義することも可能
	public void Z()
	{
		Debug.Log("他の処理");
	}
}

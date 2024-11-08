using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Assertions.Must;//Text型が含まれている名前空間を追加

public sealed class MARU3_3_1_5 : MARU3_3_1_1
{
	public void Attack()
	{
		Debug.Log("電撃体当たり");
	}

	public override void Magic()
	{
		Debug.Log("電撃魔法攻撃");
	}
}

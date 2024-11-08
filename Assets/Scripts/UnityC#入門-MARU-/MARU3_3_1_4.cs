using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Assertions.Must;//Text型が含まれている名前空間を追加

public sealed class MARU3_3_1_4 : MARU3_3_1_1
{
	public void Attack()
	{
		Debug.Log("氷結体当たり");
	}

	public override void Magic()
	{
		Debug.Log("氷結魔法攻撃");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 何個でも引数を指定できるようにする : MonoBehaviour
{
	void Start()
	{
		関数名("1996", "5", "13", "カシワバラ", "ゆうた");
	}

	public void 関数名(params object[] 変数名)
	{
		foreach (var item in 変数名)
		{
			Debug.Log(item);
		}
	}
}

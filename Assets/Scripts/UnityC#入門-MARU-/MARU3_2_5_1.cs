using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU3_2_5_1
{
	public int a;
	protected int b;
	private int c;

	public void D()
	{
		Debug.Log("関数Dが呼ばれました");
	}

	protected void E()
	{
		Debug.Log("関数Eが呼ばれました");
	}

	private void F()
	{
		Debug.Log("関数Fが呼ばれました");
	}
}

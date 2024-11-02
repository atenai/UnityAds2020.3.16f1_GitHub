using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Assertions.Must;//Text型が含まれている名前空間を追加

public class MARU3_2_5_3 : MonoBehaviour
{
	private void Start()
	{
		MARU3_2_5_2 z = new MARU3_2_5_2();

		z.a = 100;
		//z.b = 1000;

		z.D();
		//z.E();
	}
}

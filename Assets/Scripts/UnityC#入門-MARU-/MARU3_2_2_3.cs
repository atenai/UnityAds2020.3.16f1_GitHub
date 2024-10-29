using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU3_2_2_3 : MonoBehaviour
{
	void Start()
	{
		//MARU3_2_2_2クラスのインスタンスを作成し、変数zへ割り当て
		MARU3_2_2_2 z = new MARU3_2_2_2();

		//MARU3_2_2_2クラスが継承しているMARU3_2_2_1クラスの関数Aを呼び出し
		z.A();
	}
}

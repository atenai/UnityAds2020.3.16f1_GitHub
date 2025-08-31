using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ゆうたこぶん : MonoBehaviour
{
	void Start()
	{
		にしきおやびん.AddListener(Talk);
	}

	void Talk()
	{
		Debug.Log("<color=green>わかりました、母上！</color>");
	}
}

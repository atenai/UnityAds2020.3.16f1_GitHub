using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class まさあきこぶん : MonoBehaviour
{
	void Start()
	{
		にしきおやびん.AddListener(Talk);
	}

	void Talk()
	{
		Debug.Log("<color=blue>承知致しました。将軍様！</color>");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ポチ : MonoBehaviour
{
	void Start()
	{
		かしわばら家.singletonInstance.リビング();
		かしわばら家.singletonInstance.トイレ();
	}
}

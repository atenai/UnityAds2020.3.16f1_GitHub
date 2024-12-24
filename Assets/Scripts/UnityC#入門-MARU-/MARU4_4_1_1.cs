using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.UIElements;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using ACode;

public class MARU4_4_1_1 : MonoBehaviour
{
	private void Start()
	{
		Debug.Log("スタート関数開始");

		Controller controller = new Controller();
		controller.ABC();

		Debug.Log("スタート関数終了");
	}
}

namespace ACode
{
	public sealed class Controller
	{
		public void ABC()
		{
			Debug.Log("Aさんが書いたControllerクラスのABC関数");
		}
	}
}

namespace BCode
{
	public sealed class Controller
	{
		public void ABC()
		{
			Debug.Log("Bさんが書いたControllerクラスのABC関数");
		}
	}
}

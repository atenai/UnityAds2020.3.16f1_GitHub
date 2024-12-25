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
using JetBrains.Annotations;
using System.Linq;

[System.Serializable]
public class MARU4_4_7_1
{
	public int a = 100;
	public float b = 100.5f;
	public string c = "セーブしたい文字列";

	public bool d = true;
	public int[] e = new int[] { 0, 2, 4 };
	public List<int> f = new List<int> { 10, 20, 30 };

	[SerializeField] private int g = 1000;
}

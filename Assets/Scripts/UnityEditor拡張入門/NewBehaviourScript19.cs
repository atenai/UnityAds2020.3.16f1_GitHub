#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
using UnityEditor.Callbacks;
using System;
using System.IO;
using UnityEditor.iOS.Xcode;
using UnityEditor.SceneManagement;
using System.Linq;
using UnityEditor.SearchService;
using UnityEngine.Experimental;
using UnityEngine.Networking;

public class NewBehaviourScript19 : MonoBehaviour
{
	public GameObject go;

#if UNITY_EDITOR
	void OnValidate()
	{
		UnityEditor.EditorApplication.delayCall += () =>
		{
			DestroyImmediate(go);
			go = null;
		};
	}
#endif
}
#endif
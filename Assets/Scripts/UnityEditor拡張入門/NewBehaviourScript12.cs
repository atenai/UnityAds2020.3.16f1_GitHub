#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class NewBehaviourScript12
{
	static NewBehaviourScript12()
	{
		//10秒以内であれば起動時と判断する
		if (10 < EditorApplication.timeSinceStartup)
		{
			return;
		}
		Debug.Log("起動時に呼び出される");
	}
}
#endif
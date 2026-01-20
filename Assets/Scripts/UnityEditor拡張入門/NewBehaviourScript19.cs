#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class NewBehaviourScript19 : MonoBehaviour
{
	public GameObject go;

	void OnValidate()
	{
		EditorApplication.delayCall += () =>
		{
			DestroyImmediate(go);
			go = null;
		};
	}
}
#endif
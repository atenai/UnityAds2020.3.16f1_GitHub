#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

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
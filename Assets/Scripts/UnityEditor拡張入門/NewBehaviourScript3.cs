#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class NewBehaviourScript3
{
	[MenuItem("UndoExample/Undo/AddComponent")]//上のメニューに項目の追加をする
	static void AddComponent()
	{
		GameObject go = Selection.activeGameObject;

		Rigidbody rigidbody = Undo.AddComponent<Rigidbody>(go);

		//この後、Undoを実行すればコンポーネントが削除される
	}
}
#endif
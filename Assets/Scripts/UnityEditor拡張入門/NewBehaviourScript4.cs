#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class NewBehaviourScript4
{
	[MenuItem("UndoExample/Undo/RegisterCreatedObjectUndo")]//上のメニューに項目の追加をする
	static void RegisterCreatedObjectUndo()
	{
		GameObject go = Selection.activeGameObject;

		Undo.RegisterCreatedObjectUndo(go, "GameObjectを作成");

		//グループをインクリメント
		Undo.IncrementCurrentGroup();

		Hoge2 hoge = ScriptableObject.CreateInstance<Hoge2>();

		//実際にhogeがUndoされるのか確認。Undoされたらnullになる
		EditorApplication.update += () => Debug.Log(hoge);
	}
}
#endif
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

/// <summary>
/// エディタウィンドウを作る為の金型
/// </summary>
public class NewBehaviourScript23 : EditorWindow
{
	private Sprite sprite;
	Rect rect;
	private int id;

	[MenuItem("Kashiwabara/NewBehaviourScript23")]
	static void Open()
	{
		GetWindow<NewBehaviourScript23>();
	}

	//OnGUI()はEditorWindowだとエディタウィンドウに表示され、MonoBehaviourだとゲーム画面に表示される
	void OnGUI()
	{
		//マウスの位置がGUIの範囲内であれば
		if (rect.Contains(Event.current.mousePosition))
		{
			switch (Event.current.type)
			{
				//ドラッグ中
				case EventType.DragUpdated:
				case EventType.DragPerform:

					//ドラッグしているのが参照可能なオブジェクトの場合
					if (DragAndDrop.objectReferences.Length == 1)
					{
						//オブジェクトを受け入れる
						DragAndDrop.AcceptDrag();
					}

					//ドラッグしているものを現在のコントロールIDと紐づける
					DragAndDrop.activeControlID = id;

					//このオブジェクトを受け入れられるという見た目にする
					DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
					break;

				//ドラッグ終了 = ドロップ
				case EventType.DragExited:

					//ドロップしているのが参照可能なオブジェクトの場合
					if (DragAndDrop.objectReferences.Length == 1)
					{
						var reference = DragAndDrop.objectReferences[0] as Sprite;

						if (reference != null)
						{
							sprite = reference;

							HandleUtility.Repaint();
						}
					}
					break;
			}
		}
	}
}
#endif
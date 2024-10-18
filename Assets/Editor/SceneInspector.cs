using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(SceneAsset))]
public class SceneInspector : Editor
{
    GameObject scenePrefab;

    Dictionary<Editor, bool> activeEditors = new Dictionary<Editor, bool>();

    void OnEnable()
    {
        var assetPath = AssetDatabase.GetAssetPath(target);

        //プレハブ取得
        scenePrefab = ScenePrefabUtility.GetScenePrefab(assetPath);

        //無ければ生成
        if (scenePrefab == null)
        {
            scenePrefab = ScenePrefabUtility.CreateScenePrefab(assetPath, new System.Type[] { typeof(Transform) });
        }

        InitActiveEditors();

        //Undoによって変更された状態を初期化
        Undo.undoRedoPerformed += InitActiveEditors;
    }

    void OnDisable()
    {
        ClearActiveEditors();

        Undo.undoRedoPerformed -= InitActiveEditors;

        AssetDatabase.SaveAssets();
    }

    //生成したEditorオブジェクトの破棄
    void ClearActiveEditors()
    {
        foreach (var activeEditor in activeEditors)
        {
            Object.DestroyImmediate(activeEditor.Key);
        }
        activeEditors.Clear();
    }

    void InitActiveEditors()
    {
        ClearActiveEditors();

        //コンポーネントからEditorオブジェクトを生成
        foreach (var component in scenePrefab.GetComponents<Component>())
        {
            //TransformとRectTransformは省く
            //本章の目的では必要ないと判断したため
            if (component is Transform || component is RectTransform)
            {
                continue;
            }

            activeEditors.Add(Editor.CreateEditor(component), true);
        }
    }

    public override void OnInspectorGUI()
    {
        GUI.enabled = true;

        EditorGUILayout.LabelField("シーンアセットのインスペクター!");

        var editors = new List<Editor>(activeEditors.Keys);

        foreach (var editor in editors)
        {
            DrawInspectorTitlebar(editor);

            GUILayout.Space(-5f);

            if (activeEditors[editor] && editor.target != null)
            {
                editor.OnInspectorGUI();
            }

            DrawLine();
        }

        //コンテキストのRemove Componentによって削除された場合、Editor.targetはnullになる
        //その時は初期化する
        if (editors.All(e => e.target != null) == false)
        {
            InitActiveEditors();
            Repaint();
        }

        //OnInspectorGUIの最後に実装

        //残りの余った領域を取得
        var dragAndDropRect = GUILayoutUtility.GetRect(GUIContent.none, GUIStyle.none, GUILayout.ExpandHeight(true), GUILayout.MinHeight(200));

        switch (Event.current.type)
        {
            //ドラッグ中 or ドロップ実行
            case EventType.DragUpdated:
            case EventType.DragPerform:
                //マウス位置が指定の範囲外であれば無視
                if (dragAndDropRect.Contains(Event.current.mousePosition) == false)
                {
                    break;
                }

                //カーソルをコピー表示する
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                //ドロップ実行
                if (Event.current.type == EventType.DragPerform)
                {
                    DragAndDrop.AcceptDrag();

                    //ドロップしたオブジェクトがスクリプトアセットかどうか
                    var components = DragAndDrop.objectReferences.Where(x => x.GetType() == typeof(MonoScript)).OfType<MonoScript>().Select(m => m.GetClass());

                    //コンポーネントをプレハブにアタッチ
                    foreach (var component in components)
                    {
                        Undo.AddComponent(scenePrefab, component);
                    }

                    InitActiveEditors();
                }
                break;
        }

        //ドロップできる領域を確保
        GUI.Label(dragAndDropRect, "");
    }

    void DrawInspectorTitlebar(Editor editor)
    {
        var rect = GUILayoutUtility.GetRect(GUIContent.none, GUIStyle.none, GUILayout.Height(20));
        rect.x = 0;
        rect.y -= 5;
        rect.width += 20;
        activeEditors[editor] = EditorGUI.InspectorTitlebar(rect, activeEditors[editor], editor.target, true);
    }

    void DrawLine()
    {
        EditorGUILayout.Space();
        var lineRect = GUILayoutUtility.GetRect(GUIContent.none, GUIStyle.none, GUILayout.Height(2));
        lineRect.y -= 3;
        lineRect.width += 20;
        Handles.color = Color.black;

        var start = new Vector2(0, lineRect.y);
        var end = new Vector2(lineRect.width, lineRect.y);
        Handles.DrawLine(start, end);
    }
}

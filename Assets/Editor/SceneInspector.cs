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
    }

    void OnDisable()
    {
        ClearActiveEditors();
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

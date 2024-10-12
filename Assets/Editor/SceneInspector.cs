using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneAsset))]
public class SceneInspector : Editor
{
    GameObject scenePrefab;

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
    }

    public override void OnInspectorGUI()
    {
        GUI.enabled = true;

        EditorGUILayout.LabelField("シーンアセットのインスペクター!");
    }
}

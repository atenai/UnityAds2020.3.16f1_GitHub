using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ScenePrefabUtility
{
    const string PREFAB_FOLDER_PATH = "Assets/Editor/ScenePrefabs";

    [InitializeOnLoadMethod]
    static void CreatePrefabFolder()
    {
        Directory.CreateDirectory(PREFAB_FOLDER_PATH);
    }

    public static GameObject CreateScenePrefab(string scenePath, System.Type[] components)
    {
        var guid = ScenePathToGUID(scenePath);

        //HideFlagsはコンパイルエラーなどの予想外のエラーによって中断された時の対策として
        //非表示 & 保存禁止
        var go = EditorUtility.CreateGameObjectWithHideFlags(guid, HideFlags.HideAndDontSave, components);

        var prefabPath = string.Format("{0}/{1}.prefab", PREFAB_FOLDER_PATH, guid);

        var prefab = PrefabUtility.CreatePrefab(prefabPath, go);

        //プレハブ生成のために作成したゲームオブジェクトは破棄
        Object.DestroyImmediate(go);

        return prefab;
    }

    //プレハブ名をシーンアセットのguidにする
    public static GameObject GetScenePrefab(string scenePath)
    {
        //シーン名だと同名が存在する可能性があるのでguidにする
        var guid = ScenePathToGUID(scenePath);

        var prefabPath = string.Format("{0}/{1}.prefab", PREFAB_FOLDER_PATH, guid);
        return AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
    }

    private static string ScenePathToGUID(string scenePath)
    {
        return AssetDatabase.AssetPathToGUID(scenePath);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

[CreateAssetMenu(menuName = "Example/Create ExampleAssetInstance")]
public class ExampleAsset : ScriptableObject
{
    [SerializeField]
    string str;

    [SerializeField, Range(0, 10)]
    int number;

    [MenuItem("Example/CreateExampleAssetInstance")]
    static void CreateExampleAssetInstance()
    {
        var exampleAsset = CreateInstance<ExampleAsset>();

        AssetDatabase.CreateAsset(exampleAsset, "Assets/Editor/ExampleAsset.asset");
        AssetDatabase.Refresh();
    }

    [MenuItem("Example/CreateExampleAsset")]
    static void CreateExampleAsset()
    {
        var exampleAsset = CreateInstance<ExampleAsset>();

        AssetDatabase.CreateAsset(exampleAsset, "Assets/Editor/ExampleAsset.asset");
        AssetDatabase.Refresh();
    }

    [MenuItem("Example/LoadExampleAsset")]
    static void LoadExampleAsset()
    {
        var exampleAsset = AssetDatabase.LoadAssetAtPath<ExampleAsset>("Assets/Editor/ExampleAsset.asset");
        Debug.Log("<color=red>" + exampleAsset + "</color>");
    }

}

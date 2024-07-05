#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NewBehaviourScript
{
    [MenuItem("Assets/CreateExampleAssetsMaterial0")]
    static void CreateExampleAssets()
    {
        var material = new Material(Shader.Find("Standard"));

        ProjectWindowUtil.CreateAsset(material, "New Material.mat");
    }
}
#endif
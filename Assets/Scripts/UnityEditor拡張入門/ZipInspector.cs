using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Zipファイル
[CustomAsset(".zip")]
public class ZipInspector : Editor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Label("例: zip の中身をプレビューとして階層表示");
    }
}

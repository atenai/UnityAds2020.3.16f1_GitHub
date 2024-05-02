using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Excelファイル
[CustomAsset(".xlsx", ".xlsm", ".xls")]
public class ExcelInspector : Editor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Button("例: ScriptableObject に変換するボタンを追加");
    }
}

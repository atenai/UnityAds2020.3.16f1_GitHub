using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;
using UnityEditor;

/// <summary>
/// 既存のEnumを指定しているファイルに同じ物を除いた差分のEnumを追加するエディター拡張クラス
/// </summary>
public class EnumAdd : EditorWindow
{
    [MenuItem("Kashiwabara/EnumAdd", false, 1)]//上のウィンドウメニュー欄に追加される
    private static void ShowWindow()
    {
        //指定したクラス（このクラス）がウィンドウメニューの内容になる
        EnumAdd window = GetWindow<EnumAdd>();
        window.titleContent = new GUIContent("差分Enum追加Window");
    }

    void OnGUI()
    {
        if (GUILayout.Button("差分Enum追加ボタン"))
        {
            Debug.Log("差分Enum追加");
            AddEnum();
        }
    }

    // 動物の名前（Enumに変換する配列）
    string[] animals = new string[]
    {
        "Cat",
        "Dog",
        "Poti",
        "Pato",
    };

    // Enumを挿入するファイルのパス
    string insertFilePath = "Assets/Scripts/EnumAutoCreate/AnimalEnum.cs";

    void AddEnum()
    {
        List<string> cacheList = File.ReadAllLines(insertFilePath, Encoding.UTF8).ToList();

        List<string> list1 = new List<string>();
        foreach (string line1 in cacheList)
        {
            list1.Add(line1.Trim());
            Debug.Log(list1);
        }

        List<string> list2 = new List<string>();
        foreach (string line2 in animals)
        {
            list2.Add(line2.Trim() + ",");
            Debug.Log(line2);
        }

        List<string> list3 = new List<string>();
        foreach (string line3 in list2)
        {
            if (list1.Contains(line3))
            {
                Debug.Log("おなじ");
            }
            else
            {
                list3.Add(line3);
                Debug.Log("ちがう");
            }
        }

        List<string> readedLines = new List<string>();

        // 以前のEnumをそのまま入れる
        for (int i = 0; i < cacheList.Count; i++)
        {
            readedLines.Insert(i, cacheList[i]);
        }
        // Enumに新しい要素を挿入する
        for (int i = 0; i < list3.Count; i++)
        {
            readedLines.Insert(cacheList.Count - 1 + i, "\t" + list3[i]);
        }

        // Enumを挿入した状態のコードをファイルに書き込む
        File.WriteAllLines(insertFilePath, readedLines, Encoding.UTF8);
        AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);
    }
}

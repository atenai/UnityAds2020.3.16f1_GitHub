using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;
using UnityEditor;

/// <summary>
/// 配列からEnumを生成するスクリプト
/// </summary>
public class EnumCreaterSample : MonoBehaviour
{
    // 動物の名前（Enumに変換する配列）
    string[] animals = new string[]
    {
        "Cat",
        "Dog",
        "Elephant",
        "Cow",
    };

    // Enumの名前
    string enumName = "AnimalType";

    // Enumを挿入するファイルのパス
    string insertFilePath = "Assets/Scripts/EnumAutoCreate/AnimalEnum.cs";

    // Enumを挿入するスクリプトの行番号
    int insertLineNumber = 0;

    void Start()
    {
        // 行番号は１からだが配列の要素番号は０からなので合わせる
        int InsertLineNumber = insertLineNumber - 1;

        // ０よりも小さければ０にする
        if (InsertLineNumber < 0)
        {
            InsertLineNumber = 0;
        }

        // 行ごとにファイルのコードを読み込んで配列に格納する
        //（"Linq"の"ToList()"を使用して配列を"List<string>"に変換）
        //List<string> readedLines = File.ReadAllLines(insertFilePath, Encoding.UTF8).ToList();
        List<string> readedLines = new List<string>();

        // 読み込んだファイルの行数が挿入する行よりも小さければ
        if (readedLines.Count < InsertLineNumber)
        {
            // 強制的に挿入する行番号をファイルの最終行にする
            InsertLineNumber = readedLines.Count;
        }

        // Enumの名前の部分を挿入する
        readedLines.Insert(InsertLineNumber, "\t" + "public enum " + enumName);
        // Enumのカッコを挿入する
        readedLines.Insert(InsertLineNumber + 1, "\t" + "{");

        // Enumのメンバーを挿入する
        for (int i = 0; i < animals.Length; i++)
        {
            readedLines.Insert(InsertLineNumber + 2 + i, "\t\t" + animals[i] + ",");
        }

        // Enumの閉じカッコを挿入する
        readedLines.Insert(InsertLineNumber + animals.Length + 2, "\t" + "}");

        // Enumを挿入した状態のコードをファイルに書き込む
        File.WriteAllLines(insertFilePath, readedLines, Encoding.UTF8);
        AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);
    }
}
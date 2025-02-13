using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;
using UnityEditor;

/// <summary>
/// 配列からEnumを生成するスクリプト
/// こちらはスクリプトファイルを直にフォルダー内に作成するから一度Unityエディタを読み込み直さないといけない！
/// </summary>
public class EditorAnimationEnumCreater : EditorWindow
{
    [MenuItem("Kashiwabara/EditorAnimationEnumCreater", false, 1)]//上のウィンドウメニュー欄に追加される
    private static void ShowWindow()
    {
        //指定したクラス（このクラス）がウィンドウメニューの内容になる
        EditorAnimationEnumCreater window = GetWindow<EditorAnimationEnumCreater>();
        window.titleContent = new GUIContent("Enum生成Window");
    }

    void OnGUI()
    {
        if (GUILayout.Button("Enum生成ボタン"))
        {
            Debug.Log("Enum生成");
            EnumCreater();
        }
    }

    // Enumの名前
    string enumName = "AnimationType";

    // Enumを挿入するファイルのパス
    string insertFilePath = "Assets/Scripts/EnumAutoCreate/AnimationEnum.cs";

    // Enumを挿入するスクリプトの行番号
    int insertLineNumber = 0;

    void EnumCreater()
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

        List<string> nameList = new List<string>();

        GameObject unitychan = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/unity-chan!/Unity-chan! Model/Prefabs/unitychan.prefab");
        Animator animator = unitychan.gameObject.GetComponent<Animator>();

        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        int animationClipLength = clips.Length;
        for (int i = 0; i < animationClipLength; i++)
        {
            Debug.Log("<color=green>clip.name :" + clips[i].name + "</color>");
            nameList.Add(clips[i].name);
        }

        int nameListCount = nameList.Count;

        // Enumのメンバーを挿入する
        for (int i = 0; i < nameListCount; i++)
        {
            readedLines.Insert(InsertLineNumber + 2 + i, "\t\t" + nameList[i] + ",");
        }

        // Enumの閉じカッコを挿入する
        readedLines.Insert(InsertLineNumber + nameListCount + 2, "\t" + "}");

        // Enumを挿入した状態のコードをファイルに書き込む
        File.WriteAllLines(insertFilePath, readedLines, Encoding.UTF8);
    }
}
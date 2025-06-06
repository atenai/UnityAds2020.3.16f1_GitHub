using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;

/// <summary>
/// アニメーターからアニメーションクリップEnumを生成するスクリプト
/// </summary>
public class EditorAnimationEnumCreater : EditorWindow
{
    [MenuItem("Kashiwabara/EditorAnimationEnumCreater", false, 1)]//上のウィンドウメニュー欄に追加される
    private static void ShowWindow()
    {
        //指定したクラス（このクラス）がウィンドウメニューの内容になる
        EditorAnimationEnumCreater window = GetWindow<EditorAnimationEnumCreater>();
        window.titleContent = new GUIContent("UnityChanアニメーションEnum作成Window");
    }

    void OnGUI()
    {
        if (GUILayout.Button("UnityChanアニメーションEnum作成ボタン"))
        {
            Debug.Log("UnityChanアニメーションEnum作成");
            EnumCreater();
        }
    }

    // Enumの名前
    string enumName = "AnimationType";

    // Enumを挿入するファイルのパス
    string insertFilePath = "Assets/Scripts/EnumAutoCreate/AnimationEnum.cs";

    // Enumを挿入するスクリプトの行番号
    int insertLineNumber = 0;

    bool isClipName = true;

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

        if (isClipName == false)
        {
            //アニメーションクリップ名を取得
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            int animationClipLength = clips.Length;
            for (int i = 0; i < animationClipLength; i++)
            {
                Debug.Log("<color=green>clip.name :" + clips[i].name + "</color>");
                nameList.Add(clips[i].name);
            }
        }
        else
        {
            //アニメーターステート名を取得
            AnimatorController animatorController = animator.runtimeAnimatorController as AnimatorController;
            foreach (AnimatorControllerLayer layer in animatorController.layers)
            {
                foreach (ChildAnimatorState state in layer.stateMachine.states)
                {
                    Debug.Log("<color=green>state.name :" + state.state.name + "</color>");
                    nameList.Add(state.state.name);
                }
            }
        }

        List<string> resultList = new List<string>();
        foreach (string name in nameList)
        {
            if (name.Contains("@") == true)
            {

            }
            else
            {
                resultList.Add(name);
            }
        }

        int resultListCount = resultList.Count;

        // Enumのメンバーを挿入する
        for (int i = 0; i < resultListCount; i++)
        {
            readedLines.Insert(InsertLineNumber + 2 + i, "\t\t" + resultList[i] + ",");
        }

        // Enumの閉じカッコを挿入する
        readedLines.Insert(InsertLineNumber + resultListCount + 2, "\t" + "}");

        // Enumを挿入した状態のコードをファイルに書き込む
        File.WriteAllLines(insertFilePath, readedLines, Encoding.UTF8);
        AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);
    }
}
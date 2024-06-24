using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
using UnityEditor.Callbacks;
using System.IO;
using UnityEditor.iOS.Xcode;

public class NewBehaviourScript8
{
    //callbackOrderで実行順を指定することが出来る
    //0が内部で使われているorderなので1以上を指定する
    [PostProcessBuild(1)]
    static void OnPostProcessBuild(BuildTarget buildTarget, string path)
    {
        if (buildTarget != BuildTarget.iOS)
        {
            return;
        }

        //Xcodeプロジェクトのパスを取得
        var XcodeprojPath = Path.Combine(path, "Unity-iPhone.xcodeproj");
        var pbxprojPath = Path.Combine(XcodeprojPath, "project.pbxproj");

        //Xcodeプロジェクトロード
        PBXProject proj = new PBXProject();
        proj.ReadFromFile(pbxprojPath);

        var target = proj.TargetGuidByName("Unity-iPhone");

        proj.AddFrameworkToProject(target, "Social.framework", false);
        proj.WriteToFile(pbxprojPath);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;

public class DoCreateScriptAsset : EndNameEditAction
{
    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        var text = File.ReadAllText(resourceFile);

        var className = Path.GetFileNameWithoutExtension(pathName);

        //半角スペースを除く
        className = className.Replace(" ", "");

        //他のパラメーター名について知りたい場合は
        //第15章「ScriptTemplates」を参照してください
        text = text.Replace("#SCRIPTNAME#", className);

        text += "\n//コード追加！";

        //UTF8のBOM付きで保存
        var encoding = new UTF8Encoding(true, false);

        File.WriteAllText(pathName, text, encoding);

        AssetDatabase.ImportAsset(pathName);

        var asset = AssetDatabase.LoadAssetAtPath<MonoScript>(pathName);

        ProjectWindowUtil.ShowCreatedAsset(asset);
    }
}

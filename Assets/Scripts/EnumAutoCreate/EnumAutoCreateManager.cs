using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumAutoCreateManager : MonoBehaviour
{
    //Enumの項目をstringでまとめる
    List<string> itemNameList = new List<string>()
    {
        "Hoge", "Hage", "Age", "NagaiNamaeNoAitemu"
    };

    void Start()
    {
        //Enum作成
        EnumCreator.Create
        (
        enumName: "TestEnum",          //enumの名前
        itemNameList: itemNameList,        //enumの項目
        exportPath: "Assets/Scripts/EnumAutoCreate/TestEnum.cs",//作成したファイルのパスをAssetsから拡張子まで指定
          /*以下は省略可能*/
          summary: "さまりー",             //enumの説明
          nameSpace: "Test",              //nameSpaceの名前
          isFlags: true                 //Flag属性を付けるあどうか
        );
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オリジナルのアトリビュートを作成する際は、PropertyAttributeクラスを継承する必要がある
/// またクラス名は○○Attributeという名前にする必要がある
/// ○○の部分がアトリビュート名になる
/// 例としてこのクラスPopupAttributeなら、[Popup("Hoge", "Fuga", "Foo", "Bar")]という風に書いて使用することができる
/// 参考サイト : https://www.hanachiru-blog.com/entry/2022/04/20/153950
/// </summary>
public class PopupAttribute : PropertyAttribute
{
    public object[] list;

    //引数はobject配列
    public PopupAttribute(params object[] list)
    {
        this.list = list;
    }
}

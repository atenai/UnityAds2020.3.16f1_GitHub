using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// usingステートメント
/// https://qiita.com/yaegaki/items/227f026344a8729fbd43
/// </summary>
public class UsingTest : MonoBehaviour
{
    void Start()
    {
        //usingステートメントの処理の流れ//
        //↓
        //1.引数に入れたクラスのコンストラクタが実行
        //↓
        //2.{}内の中身を上から全て実行
        //↓
        //3.引数に入れたクラスのDispose関数が実行

        using (new Kashiwabara())//usingステートメントは引数にnewをつけてクラスを入れる必要がある
        {
            Debug.Log("<color=red>1</color>");
            Debug.Log("<color=blue>2</color>");
        }
    }
}

public class Kashiwabara : IDisposable//usingステートメント用クラスはIDisposableを継承する必要がある
{
    //コンストラクタ
    public Kashiwabara()
    {
        Debug.Log("<color=green>Kashiwabara</color>");
    }

    //通常の関数は実行されない
    public void Yuta()
    {
        Debug.Log("<color=orange>Yuta</color>");
    }

    //IDisposableを継承した場合はDispose関数を作る必要がある
    public void Dispose()
    {
        Debug.Log("<color=yellow>Dispose</color>");
    }
}
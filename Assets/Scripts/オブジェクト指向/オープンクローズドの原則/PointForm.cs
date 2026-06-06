using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PointForm : MonoBehaviour
{
    [SerializeField] private Button pointButton;
    [SerializeField] private Text pointLabel;
    [SerializeField] private Button DeadLineButton;
    [SerializeField] private Text DeadLineLabel;
    private string _cardNo;
    //ここで抽象クラスの変数を宣言する
    private IPoint _point;

    //※抽象クラスを継承した新しいクラスを作成した際に、追加する部分を生成処理の部分のみに抑えるのがオープンクローズドの原則

    void Start()
    {
        pointButton.onClick.AddListener(PointButtonClicked);
        DeadLineButton.onClick.AddListener(DeadLineButtonClicked);
    }

    public void Initialize(string cardNo)
    {
        _cardNo = cardNo;
        Debug.Log($"PointFormが作成されました！カード番号: {_cardNo}");

        // 1.抽象クラスを継承したクラスのインスタンスを分岐して生成する
        // if (_cardNo.Substring(0, 1) == "P")
        // {
        //     _point = new PointPay();
        // }
        // else if (_cardNo.Substring(0, 1) == "A")
        // {
        //     _point = new AnaPoint();
        // }
        // else if (_cardNo.Substring(0, 1) == "J")
        // {
        //     _point = new JALPoint();
        // }
        // else
        // {
        //     _point = new MyPoint();
        // }

        // 2.抽象クラスを継承したクラスのインスタンスを分岐して生成する処理をファクトリークラスで行う
        _point = PointFactories.CreatePoint(_cardNo);
    }

    private void PointButtonClicked()
    {
        // ポイントボタンがクリックされたときの処理をここに記述
        Debug.Log("ポイントボタンがクリックされました！");

        int price = 100;
        //抽象クラスの関数を呼び出す
        int point = _point.GetPoint(price);
        Debug.Log($"獲得ポイント: {point}");
        pointLabel.text = point + "p";
    }

    private void DeadLineButtonClicked()
    {
        // 有効期限ボタンがクリックされたときの処理をここに記述
        Debug.Log("有効期限ボタンがクリックされました！");

        //抽象クラスの関数を呼び出す
        DateTime deadline = _point.GetDeadLine();
        Debug.Log($"ポイントの有効期限: {deadline}");
        DeadLineLabel.text = deadline.ToString("yyyy/MM/dd");
    }

}

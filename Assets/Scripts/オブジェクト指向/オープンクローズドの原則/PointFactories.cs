using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PointFactories
{
    public static IPoint CreatePoint(string _cardNo)
    {
        // 抽象クラスを継承したクラスのインスタンスを分岐して生成する
        if (_cardNo.Substring(0, 1) == "P")
        {
            return new PointPay();
        }

        if (_cardNo.Substring(0, 1) == "A")
        {
            return new AnaPoint();
        }

        if (_cardNo.Substring(0, 1) == "J")
        {
            return new JALPoint();
        }

        return new MyPoint();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointPay : IPoint
{
    public int GetPoint(int price)
    {
        return Convert.ToInt32(price * 0.02f); // 2%のポイントを計算
    }

    public DateTime GetDeadLine()
    {
        return DateTime.Now.AddDays(30); // ポイントの有効期限は30日後
    }
}

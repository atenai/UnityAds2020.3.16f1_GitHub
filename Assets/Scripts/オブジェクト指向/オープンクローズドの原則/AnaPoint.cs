using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnaPoint : IPoint
{
    public int GetPoint(int price)
    {
        return Convert.ToInt32(price * 0.03f); // 3%のポイントを計算
    }

    public DateTime GetDeadLine()
    {
        return DateTime.Now.AddDays(60); // ポイントの有効期限は60日後
    }
}

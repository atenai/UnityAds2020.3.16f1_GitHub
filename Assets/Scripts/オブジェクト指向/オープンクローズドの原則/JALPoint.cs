using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JALPoint : IPoint
{
    public int GetPoint(int price)
    {
        return Convert.ToInt32(price * 0.04f); // 4%のポイントを計算
    }

    public DateTime GetDeadLine()
    {
        return DateTime.Now.AddDays(90); // ポイントの有効期限は90日後
    }
}

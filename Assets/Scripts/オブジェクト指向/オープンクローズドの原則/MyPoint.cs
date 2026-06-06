using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyPoint : IPoint
{
    public int GetPoint(int price)
    {
        var result = Convert.ToInt32(price * 0.01f); // 1%のポイントを計算
        if (DateTime.Now.Day == 5)
        {
            return result * 5;
        }
        return result;
    }

    public DateTime GetDeadLine()
    {
        return DateTime.Now.AddDays(5); // ポイントの有効期限は5日後
    }
}

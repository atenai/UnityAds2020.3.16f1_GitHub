using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Member
{
    public override int GetPoints(int price)
    {
        return (int)(price * 0.2f);
    }
}

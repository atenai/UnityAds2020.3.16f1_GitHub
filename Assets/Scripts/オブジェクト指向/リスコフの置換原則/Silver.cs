using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silver : Member
{
    public override int GetPoints(int price)
    {
        return (int)(price * 0.1f);
    }
}

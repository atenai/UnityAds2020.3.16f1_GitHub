using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Member
{
    public enum MemberKind
    {
        Silver,
        Gold,
        Platinum
    }
    public abstract int GetPoints(int price);

    public static Member Create(MemberKind memberKind)
    {
        if (memberKind == MemberKind.Gold)
        {
            return new Gold();
        }

        return new Silver();
    }
}

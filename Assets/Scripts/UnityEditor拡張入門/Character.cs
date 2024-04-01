using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Range(0, 255)]
    public int 基本攻撃力;
    [Range(0, 99)]
    public int 剣の強さ;
    [Range(0, 99)]
    public int ちから;

    //プレイヤーの能力と、剣の強さから攻撃力を求めるプロパティ
    public int 攻撃力
    {
        get
        {
            return 基本攻撃力 + Mathf.FloorToInt(基本攻撃力 * (剣の強さ + ちから - 8) / 16);
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU2_4_4_1 : MonoBehaviour
{
    //Image型の変数Aを宣言
    public Image A;

    //Sprite型の変数Bを宣言
    public Sprite B;

    void Start()
    {
        //Debug.Log("Start");

        //Image型の変数sprite(Sprite型)にSprite型の変数Bのデータを割り当て
        A.sprite = B;
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU2_4_3_1 : MonoBehaviour
{
    //RectTransform型の変数Aを宣言
    public RectTransform A;

    void Start()
    {
        //Debug.Log("Start");

        //位置X　位置Y　位置Zを変更
        //RectTransform型の変数localPosition(Vector3)にデータを割り当て
        A.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

        //幅　高さを変更
        //RectTransform型の変数sizeDelta(Vector3)にデータを割り当て
        A.sizeDelta = new Vector2(200.0f, 50.0f);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

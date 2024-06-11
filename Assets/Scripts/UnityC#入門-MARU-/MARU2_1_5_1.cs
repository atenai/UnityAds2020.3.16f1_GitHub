using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU2_1_5_1 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        int score = 1000;

        Debug.Log("あなたのスコアは" + score + "です。");
        Debug.Log($"あなたのスコアは{score}です。");
        Debug.Log(string.Format("あなたのスコアは{0}です。", score));
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

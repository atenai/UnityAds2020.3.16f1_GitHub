using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_6_5_3 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");
        B("今日は");
        B("虹が");
        B("出ています。");
    }

    void Update()
    {
        //Debug.Log("Update");
    }

    void B(string bbb)
    {
        Debug.Log(bbb);
    }
}

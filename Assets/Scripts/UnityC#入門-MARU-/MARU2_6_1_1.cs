using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU2_6_1_1 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        int score = 1000;

        Debug.Log(500 <= score ? "Aランクです。" : "Bランクです。");
        Debug.Log(1100 <= score ? true : false);
        Debug.Log(1200 <= score ? 4444 : 9999);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

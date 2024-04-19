using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_5_3_1 : MonoBehaviour
{
    int[] scoreArray = { 10, 20, 30, 40, 50 };
    void Start()
    {
        //Debug.Log("Start");

        // foreach (var score in scoreArray)
        // {
        //     Debug.Log(score);
        // }

        Debug.Log(scoreArray[3]);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

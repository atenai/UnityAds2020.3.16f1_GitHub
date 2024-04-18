using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_5_2_1 : MonoBehaviour
{
    int[] scoreArray = new int[5];
    void Start()
    {
        //Debug.Log("Start");

        scoreArray[0] = 10;
        scoreArray[1] = 20;
        scoreArray[2] = 30;
        scoreArray[3] = 40;
        scoreArray[4] = 50;

        foreach (var score in scoreArray)
        {
            Debug.Log(score);
        }
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

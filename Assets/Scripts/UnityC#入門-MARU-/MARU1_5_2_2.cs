using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_5_2_2 : MonoBehaviour
{
    int[] scoreArray = { 110, 120, 130, 140, 150 };
    void Start()
    {
        //Debug.Log("Start");

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MARU2_1_8_2 : MonoBehaviour
{

    //配列
    int[] scoreArray = { 10, 20, 30, 40, 50 };

    //List
    List<int> scoreList = new List<int>() { 10, 20, 30, 40, 50 };

    void Start()
    {
        //Debug.Log("Start");

        //List<int> scoreList;
        //scoreList = new List<int>();

        // scoreList.Add(10);
        // scoreList.Add(20);
        // scoreList.Add(30);
        // scoreList.Add(40);
        // scoreList.Add(50);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

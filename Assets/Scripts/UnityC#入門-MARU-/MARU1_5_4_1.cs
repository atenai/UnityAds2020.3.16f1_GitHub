using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_5_4_1 : MonoBehaviour
{
    int[] numberArray = { 10, 20, 30, 40, 50 };
    void Start()
    {
        //Debug.Log("Start");

        for (int i = 0; i < 5; i++)
        {
            Debug.Log(numberArray[i]);
        }
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

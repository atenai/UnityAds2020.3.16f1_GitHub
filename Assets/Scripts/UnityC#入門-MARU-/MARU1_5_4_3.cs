using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_5_4_3 : MonoBehaviour
{
    int[] numberArray = new int[16];
    void Start()
    {
        //Debug.Log("Start");

        for (int i = 0; i < numberArray.Length; i++)
        {
            numberArray[i] = i * 20;
            Debug.Log(numberArray[i]);
        }
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

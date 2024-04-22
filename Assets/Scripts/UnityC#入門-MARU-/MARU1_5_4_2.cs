using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_5_4_2 : MonoBehaviour
{
    int[] numberArray = { 10, 20, 30, 40, 50 };
    void Start()
    {
        //Debug.Log("Start");

        Debug.Log(numberArray.Length);

        for (int i = 0; i < numberArray.Length; i++)
        {
            Debug.Log(numberArray[i]);
        }
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_3_2_1 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");

        if (10 == 100)
        {
            Debug.Log("10 == 100は正しい");
        }

        if (10 != 100)
        {
            Debug.Log("10 != 100は正しい");
        }

        if (10 < 100)
        {
            Debug.Log("10 < 100は正しい");
        }

        if (10 > 100)
        {
            Debug.Log("10 > 100は正しい");
        }

        if (10 <= 100)
        {
            Debug.Log("10 <= 100は正しい");
        }

        if (10 >= 100)
        {
            Debug.Log("10 >= 100は正しい");
        }
    }

    void Update()
    {
        Debug.Log("Update");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_4_3_3 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        for (int i = 0; i < 4; i++)
        {
            if (i == 2)
            {
                break;
            }
            Debug.Log("i = " + i);
        }

        Debug.Log("Start関数の終了");
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

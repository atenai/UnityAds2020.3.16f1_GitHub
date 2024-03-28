using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_3_5_1 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");

        int score = 700;

        if (score < 500)
        {
            Debug.Log("Bランク");
        }
        else if (score < 1000)
        {
            Debug.Log("Aランク");
        }
        else
        {
            Debug.Log("Sランク");
        }
    }

    void Update()
    {
        Debug.Log("Update");
    }
}

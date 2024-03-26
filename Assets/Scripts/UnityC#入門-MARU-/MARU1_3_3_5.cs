using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_3_3_5 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");

        Debug.Log(true || true);
        Debug.Log(true || false);
        Debug.Log(false || true);
        Debug.Log(false || false);
    }

    void Update()
    {
        Debug.Log("Update");
    }
}

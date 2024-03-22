using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_2_5_2 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");

        int a = 10;

        a++;
        Debug.Log(a);

        ++a;
        Debug.Log(a);

        a--;
        Debug.Log(a);

        --a;
        Debug.Log(a);
    }

    void Update()
    {
        Debug.Log("Update");
    }
}

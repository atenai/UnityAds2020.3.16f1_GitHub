using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU2_4_1_2 : MonoBehaviour
{
    private int a = 1000;

    private void Start()
    {
        //Debug.Log("Start");

        int b = 100;

        Debug.Log(a);
        Debug.Log(b);

        C();
    }

    void Update()
    {
        //Debug.Log("Update");
    }

    private void C()
    {
        Debug.Log("テスト");
    }
}

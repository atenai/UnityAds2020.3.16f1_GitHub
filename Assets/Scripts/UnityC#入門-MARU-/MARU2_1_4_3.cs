using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU2_1_4_3 : MonoBehaviour
{
    public int a = 1000;

    public void Start()
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

    public void C()
    {
        Debug.Log("テスト");
    }
}

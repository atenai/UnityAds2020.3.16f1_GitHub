using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU2_5_8_1 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start関数呼び出し");
    }

    void Update()
    {
        Debug.Log("Update");
    }

    void LateUpdate()
    {
        //Debug.Log("LateUpdate");
    }

    void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}

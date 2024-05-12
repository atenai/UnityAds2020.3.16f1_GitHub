using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_6_9_1 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        //計算対象
        float targetNumber = 11.5f;

        //計算対象を切り捨て
        float floorResult = Mathf.Floor(targetNumber);
        Debug.Log("floorResult = " + floorResult);

        //計算対象を切り上げ
        float ceilResult = Mathf.Ceil(targetNumber);
        Debug.Log("ceilResult = " + ceilResult);

        //計算対象を四捨五入
        float roundResult = Mathf.Round(targetNumber);
        Debug.Log("roundResult = " + roundResult);
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

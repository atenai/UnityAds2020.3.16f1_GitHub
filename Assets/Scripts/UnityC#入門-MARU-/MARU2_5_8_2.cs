using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU2_5_8_2 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start関数呼び出し");
    }

    void Update()
    {
        //Debug.Log("Update");
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
        Debug.Log(collision.gameObject.name + "との接触開始");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "との接触中");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "との接触終了");
    }
}

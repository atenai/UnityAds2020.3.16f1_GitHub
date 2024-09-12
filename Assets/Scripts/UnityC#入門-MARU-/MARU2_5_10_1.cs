using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU2_5_10_1 : MonoBehaviour
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + "との接触開始");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + "との接触中");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + "との接触終了");
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name + "との接触開始");
    }

    private void OnTriggerStay(Collider collider)
    {
        Debug.Log(collider.gameObject.name + "との接触中");
    }

    private void OnTriggerExit(Collider collider)
    {
        Debug.Log(collider.gameObject.name + "との接触終了");
    }
}

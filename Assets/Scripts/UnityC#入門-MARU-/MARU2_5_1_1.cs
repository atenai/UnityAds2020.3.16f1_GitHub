using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;//Text型が含まれている名前空間を追加

public class MARU2_5_1_1 : MonoBehaviour
{
    //Awakeはスクリプトを非アクティブにしても呼び出される
    void Awake()
    {
        Debug.Log("Awake関数呼び出し");
    }

    void Start()
    {
        Debug.Log("Start関数呼び出し");
    }

    void Update()
    {
        //Debug.Log("Update");
    }
}

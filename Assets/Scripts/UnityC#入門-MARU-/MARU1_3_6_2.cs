using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_3_6_2 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");

        int a = 3;

        switch (a)
        {
            case 0:
                Debug.Log("aは0です");
                break;
            case 1:
                Debug.Log("aは1です");
                break;
            case 2:
                Debug.Log("aは2です");
                break;
            case 3:
                Debug.Log("aは3です");
                break;
            default:
                Debug.Log("aは0,1,2,3以外です");
                break;
        }
    }

    void Update()
    {
        Debug.Log("Update");
    }
}

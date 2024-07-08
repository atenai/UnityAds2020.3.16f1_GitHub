using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineMain : MonoBehaviour
{
    EngineBox engineBox;

    bool isTest = true;
    int num = 0;

    void Start()
    {
        engineBox = new EngineBox();
    }

    void Update()
    {
        if (isTest == true)
        {
            num++;
            if (num < 100)
            {
                engineBox.EngineBoxUp();
                //Debug.Log(pEBox.EngineBoxState);
            }
            else
            {
                isTest = false;
                num = 0;
            }
        }
        else if (isTest == false)
        {
            num++;
            if (num < 100)
            {
                engineBox.EngineBoxDown();
                //Debug.Log(pEBox.EngineBoxState);
            }
            else
            {
                isTest = true;
                num = 0;
            }
        }

    }
}

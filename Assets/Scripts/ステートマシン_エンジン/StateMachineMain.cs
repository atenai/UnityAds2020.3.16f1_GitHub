using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// メイン関数
/// </summary>
public class StateMachineMain : MonoBehaviour
{
    EngineBox engineBox;

    void Start()
    {
        engineBox = new EngineBox();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            engineBox.EngineBoxUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            engineBox.EngineBoxDown();
        }

        engineBox.NowState();
    }
}

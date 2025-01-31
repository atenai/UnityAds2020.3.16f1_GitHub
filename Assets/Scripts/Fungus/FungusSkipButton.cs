using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungusSkipButton : MonoBehaviour
{
    [SerializeField] DialogInput dialogInput;

    bool isSkip = false;

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (isSkip == true)
        {
            dialogInput.SetNextLineFlag();
        }
        else
        {

        }
    }

    void OnEnable()
    {
        Init();
    }

    void OnDisable()
    {
        Init();
    }

    void Init()
    {
        isSkip = false;
    }

    /// <summary>
    /// イベントトリガーの押した際に行う関数
    /// </summary> 
    public void OnEventTriggerPointerDown()
    {
        isSkip = true;
    }

    /// <summary>
    /// イベントトリガーの離した際に行う関数
    /// </summary>
    public void OnEventTriggerPointerUp()
    {
        isSkip = false;
    }
}

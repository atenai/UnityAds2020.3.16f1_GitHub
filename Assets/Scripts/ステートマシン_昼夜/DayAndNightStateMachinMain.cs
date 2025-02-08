using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNightStateMachinMain : MonoBehaviour
{
    SafeFrame safeFrame = new SafeFrame();

    void Start()
    {
        StartCoroutine(DayAndNight());
    }

    void Update()
    {

    }

    IEnumerator DayAndNight()
    {
        for (int hour = 0; hour < 24; hour++)
        {
            safeFrame.SetClock(hour);
            safeFrame.SetUpdate();

            //停止
            yield return new WaitForSeconds(2);
        }
    }
}

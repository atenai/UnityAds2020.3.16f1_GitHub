using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TimeControl
{
    private double m_lastFrameEditorTime = 0;
    public bool isPlaying { get; private set; }
    public float minTime { get; private set; }
    public float maxTime { get; private set; }
    private float m_currentTime;
    public float CurrentTime
    {
        get
        {
            m_currentTime = Mathf.Repeat(m_currentTime, maxTime);
            m_currentTime = Mathf.Clamp(m_currentTime, minTime, maxTime);
            return m_currentTime;
        }
        set
        {
            m_currentTime = value;
        }
    }
    public float Speed { get; set; }

    public TimeControl()
    {
        Speed = 1;
        EditorApplication.update += TimeUpdate;
    }

    public void TimeUpdate()
    {
        if (isPlaying)
        {
            var timeSinceStartup = EditorApplication.timeSinceStartup;
            var deltaTime = timeSinceStartup - m_lastFrameEditorTime;
            m_lastFrameEditorTime = timeSinceStartup;
            m_currentTime += (float)deltaTime * Speed;
        }
    }

    public void Play()
    {
        isPlaying = true;
        m_lastFrameEditorTime = EditorApplication.timeSinceStartup;
    }

    public void Pause()
    {
        isPlaying = false;
    }

    public void Stop()
    {
        isPlaying = false;
        m_currentTime = 0;
    }

    public void SetMinMaxTime(float minTime, float maxTime)
    {
        this.minTime = minTime;
        this.maxTime = maxTime;
    }
}

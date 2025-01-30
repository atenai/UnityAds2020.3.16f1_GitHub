using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;
using System.Reflection;

public class FastForwardDialogue : MonoBehaviour
{

    public Writer writer;//FungusのWriterコンポーネントをアタッチ
    public Button fastForwardButton;

    private bool isFastForwarding = false;
    private float defaultSpeed = 60;

    void Start()
    {
        defaultSpeed = GetWritingSpeed();

        if (fastForwardButton != null)
        {
            fastForwardButton.onClick.AddListener(ToggleFastForward);
        }
    }

    void Update()
    {

    }

    void ToggleFastForward()
    {
        isFastForwarding = !isFastForwarding;

        if (isFastForwarding == true)
        {
            SetWritingSpeed(1000f);
        }
        else
        {
            SetWritingSpeed(defaultSpeed);
        }
    }

    float GetWritingSpeed()
    {
        FieldInfo field = typeof(Writer).GetField("writingSpeed", BindingFlags.NonPublic | BindingFlags.Instance);
        return field != null ? (float)field.GetValue(writer) : 60;
    }

    void SetWritingSpeed(float speed)
    {
        FieldInfo field = typeof(Writer).GetField("writingSpeed", BindingFlags.NonPublic | BindingFlags.Instance);
        if (field != null)
        {
            field.SetValue(writer, speed);
        }
    }
}

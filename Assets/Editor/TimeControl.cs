using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TimeControl : MonoBehaviour
{
    public bool isPlaying { get; private set; }
    private float currentTime { get; set; }
    private double lastFrameEditorTime { get; set; }
    public float speed { get; set; }

    public TimeControl()
    {
        speed = 1;
        EditorApplication.update += Update;
    }

    public void Update()
    {
        if (isPlaying)
        {
            var timeSinceStartup = EditorApplication.timeSinceStartup;
            var deltaTime = timeSinceStartup - lastFrameEditorTime;
            lastFrameEditorTime = timeSinceStartup;
            currentTime += (float)deltaTime * speed;
        }
    }

    public float GetCurrentTime(float stopTime)
    {
        return Mathf.Repeat(currentTime, stopTime);
    }

    public void Play()
    {
        isPlaying = true;
        lastFrameEditorTime = EditorApplication.timeSinceStartup;
    }

    public void Pause()
    {
        isPlaying = false;
    }

    TimeControl timeControl = new TimeControl();
    private void DrawPlayButton()
    {
        var playButtonContent = EditorGUIUtility.IconContent("PlayButton");
        var pauseButtonContent = EditorGUIUtility.IconContent("PauseButton");
        var previewButtonSettingsStyle = new GUIStyle("preButton");
        var buttonContent = timeControl.isPlaying ? pauseButtonContent : playButtonContent;

        EditorGUI.BeginChangeCheck();
        var isPlaying = GUILayout.Toggle(timeControl.isPlaying, buttonContent, previewButtonSettingsStyle);
        if (EditorGUI.EndChangeCheck())
        {
            if (isPlaying)
            {
                timeControl.Play();
            }
            else
            {
                timeControl.Pause();
            }
        }
    }

    private void DrawSpeedSlider()
    {
        var preSlider = new GUIStyle("preSlider");
        var preSliderThumb = new GUIStyle("preSliderThumb");
        var preLabel = new GUIStyle("preLabel");
        var speedScale = EditorGUIUtility.IconContent("SpeedScale");

        GUILayout.Box(speedScale, preLabel);
        timeControl.speed = GUILayout.HorizontalSlider(timeControl.speed, 0, 10, preSlider, preSliderThumb);
        GUILayout.Label(timeControl.speed.ToString("0.00"), preLabel, GUILayout.Width(40));
    }

    // private List<Editor> GetSpriteEditors(params Sprite[] sprites)
    // {
    //     var type = Types.GetType("UnityEditor.SpriteInspector", "UnityEditor.dll");
    //     var editors = new List<Editor>();

    //     foreach (var sprite in sprites)
    //     {
    //         Editor _editor = Editor.CreateEditor(sprite, type);

    //         if (_editor != null)
    //         {
    //             editors.Add(_editor);
    //         }
    //     }

    //     return editors;
    // }

    // public void OnDisable()
    // {
    //     foreach (var spriteEditor in spriteEditors)
    //     {
    //         Object.DestroyImmediate(spriteEditor);
    //     }
    // }
}

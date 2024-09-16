#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor;
using UnityEngine;
using System.Linq;
using UnityEngine.Timeline;
using UnityEngine.InputSystem;

public class NewBehaviourScript27 : EditorWindow
{
    [MenuItem("Kashiwabara/NewBehaviourScript27")]
    static void Open()
    {
        GetWindow<NewBehaviourScript27>();
    }

    //OnGUI()はEditorWindowだとエディタウィンドウに表示され、MonoBehaviourだとゲーム画面に表示される
    // void OnGUI()
    // {
    //     GUILayout.HorizontalSlider(value, leftValue, rightValue, "box", "box", GUILayout.Height(40), GUILayout.ExpandWidth(true));

    //     var timeLength = timeControl.maxTime - timeControl.minTime;
    //     //時間の長さ
    //     var gridline = timeLength * 2;//0.5目盛ごと
    //     var sliderRect = new Rect(leftRect);//タイムラインSliderのRect

    //     for (int i = 1; i < gridline; i++)
    //     {
    //         var x = (sliderRect.width / gridline) * i;
    //         x += 4f - 1.5f * (i - 1);

    //         Handles.DrawLine(new Vector2(sliderRect.x + x, sliderRect.y), new Vector2(sliderRect.x + x, sliderRect.y + sliderRect.height));
    //         Handles.Label(new Vector2(sliderRect.x + x - 10, sliderRect.y - 10), (timeLength / gridline * i).ToString("0.0"));
    //     }

    //     if (Event.current.type == EventType.KeyDown)
    //     {
    //         //再生中であれば一時停止させる
    //         timeControl.Pause();

    //         if (Event.current.keyCode == KeyCode.RightArrow)
    //         {
    //             timeControl.currentTime += 0.01f;
    //         }

    //         if (Event.current.keyCode == KeyCode.LeftArrow)
    //         {
    //             timeControl.currentTime -= 0.01f;
    //         }

    //         GUI.changed = true;
    //         Event.current.Use();
    //         Repaint();
    //     }

    //     playlist[key] = GUILayout.Toggle(playlist[key], Key.name, EditorStyles.miniButton, GUILayout.MaxWidth(position.width / 3));
    // }

    bool IsRoot(ParticleSystem ps)
    {
        var parent = ps.transform.parent;
        //親のいないParticleSystemであればルート
        if (parent == null)
        {
            return true;
        }

        //親がいてもParticleSystemコンポーネントがなければルート
        return parent.GetComponent<ParticleSystem>() == false;
    }
}
#endif
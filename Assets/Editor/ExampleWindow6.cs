using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class ExampleWindow6 : EditorWindow
{
    [MenuItem("Kashiwabara/Example6")]
    static void Open()
    {
        GetWindow<ExampleWindow6>();
    }

    //初期値が0だとフェードを行わないと判断されるため0.0001fというような0に近い値にする
    AnimFloat animFloat = new AnimFloat(0.0001f);
    Texture tex;

    void OnGUI()
    {
        bool on = animFloat.value == 1;

        if (GUILayout.Button(on ? "Close" : "Open", GUILayout.Width(64)))
        {
            animFloat.target = on ? 0.0001f : 1;
            animFloat.speed = 0.05f;

            //値が変わるごとにEditorWindowを再描画する
            var env = new UnityEvent();
            env.AddListener(() => Repaint());
            animFloat.valueChanged = env;
        }

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.BeginFadeGroup(animFloat.value);
        Display();
        EditorGUILayout.EndFadeGroup();
        Display();
        EditorGUILayout.EndHorizontal();
    }

    void Display()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.ToggleLeft("Toggle", false);
        var options = new[] { GUILayout.Width(128), GUILayout.Height(128) };

        tex = EditorGUILayout.ObjectField(tex, typeof(Texture), false, options) as Texture;
        GUILayout.Button("Button");
        EditorGUILayout.EndVertical();
    }
}

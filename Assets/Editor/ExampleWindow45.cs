#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

/// <summary>
/// 時間制御クラスのサンプル
/// </summary>
public class ExampleWindow45 : EditorWindow
{
	TimeControl timeControl;

	[MenuItem("Kashiwabara/Example45")]
	static void Open()
	{
		GetWindow<ExampleWindow45>();
	}

	void OnEnable()
	{
		timeControl = new TimeControl();
		timeControl.SetMinMaxTime(0, 10);
	}

	void OnGUI()
	{
		var buttonText = timeControl.isPlaying ? "Pause" : "Play";

		if (GUILayout.Button(buttonText))
		{
			if (timeControl.isPlaying)
			{
				timeControl.Pause();
			}
			else
			{
				timeControl.Play();
			}
		}

		timeControl.CurrentTime = EditorGUILayout.Slider(timeControl.CurrentTime, 0, 10);

		//GUI更新
		if (timeControl.isPlaying)
		{
			Repaint();
		}
	}
}
#endif
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Reflection;

[InitializeOnLoad]
public class CompileError
{
	//効果音、自由に変更する
	const string musicPath = "Assets/Editor/nc32797.wav";
	const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;

	static CompileError()
	{
		EditorApplication.playmodeStateChanged += () =>
		{

			//再生ボタンを押した時であること
			if (!EditorApplication.isPlayingOrWillChangePlaymode && EditorApplication.isPlaying)
			{
				return;
			}

			//SceneViewが存在すること
			if (SceneView.sceneViews.Count == 0)
			{
				return;
			}

			EditorApplication.delayCall += () =>
			{
				var content = typeof(EditorWindow).GetField("m_Notification", flags).GetValue(SceneView.sceneViews[0]) as GUIContent;

				if (content != null && !string.IsNullOrEmpty(content.text))
				{
					GetAudioSource().Play();
				}
			};
		};
	}

	static AudioSource GetAudioSource()
	{
		var gameObjectName = "HideAudioSourceObject";
		var gameObject = GameObject.Find(gameObjectName);

		if (gameObject == null)
		{
			//HideAndDontSaveフラグを立てて非表示・保存しないようにする
			gameObject = EditorUtility.CreateGameObjectWithHideFlags(gameObjectName, HideFlags.HideAndDontSave, typeof(AudioSource));
		}

		var hideAudioSource = gameObject.GetComponent<AudioSource>();

		if (hideAudioSource.clip == null)
		{
			hideAudioSource.clip = AssetDatabase.LoadAssetAtPath(musicPath, typeof(AudioClip)) as AudioClip;
		}

		return hideAudioSource;
	}
}
#endif
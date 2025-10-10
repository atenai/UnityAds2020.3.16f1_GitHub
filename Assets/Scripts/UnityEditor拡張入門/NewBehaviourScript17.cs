#if UNITY_EDITOR
using UnityEditor;

public class NewBehaviourScript17
{
	[InitializeOnLoadMethod]
	static void CheckPlaymodeState()
	{
		EditorApplication.playmodeStateChanged += () =>
		{
			if (EditorApplication.isPaused == true)
			{
				//一時停止中
			}

			if (EditorApplication.isPlaying == true)
			{
				//再生中
			}

			if (EditorApplication.isPlayingOrWillChangePlaymode == true)
			{
				//再生中または再生ボタンを押した直後
				//コンパイルやさまざまな処理が走っている状態
				//また、再生をやめるときにも呼び出される
			}
		};
	}
}
#endif
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

public class NewBehaviourScript16
{
	[InitializeOnLoadMethod]
	static void DrawCameraNames()
	{
		//プラットフォームごとにbundleIdentifierを切り替える
		EditorUserBuildSettings.activeBuildTargetChanged += () =>
		{
			var selected = 0;
			var displayNames = new string[0];
			var windowRect = new Rect(10, 20, 200, 24);

			//変更があれば初期化
			EditorApplication.hierarchyWindowChanged += () =>
			{
				var cameras = Object.FindObjectsOfType<Camera>();
				var cameraNames = new string[0];

				//マルチシーンであれば、どのシーンにあるカメラかを把握できるようにする
				if (1 < UnityEngine.SceneManagement.SceneManager.loadedSceneCount)
				{
					//Main Camera(Stage 1.unity)という表示名にする
					cameraNames = cameras.Select(camera => new
					{
						cameraName = camera.name,
						sceneName = Path.GetFileName(AssetDatabase.GetAssetOrScenePath(camera))
					}).Select(x => string.Format("{0} ({1})", x.cameraName, x.sceneName)).ToArray();
				}
				else
				{
					cameraNames = cameras.Select(c => c.name).ToArray();

					displayNames = new[] { "None", "" };
				}
				ArrayUtility.AddRange(ref displayNames, cameraNames);
			};

			//任意のタイミングで呼び出すこともできる
			EditorApplication.hierarchyWindowChanged();

			//全シーンビューのGUIデリゲート
			SceneView.onSceneGUIDelegate += (SceneView) =>
			{
				GUI.skin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector);

				Handles.BeginGUI();

				int windowID = EditorGUIUtility.GetControlID(FocusType.Passive, windowRect);
				//シーンビューにウィンドウを追加
				windowRect = GUILayout.Window(windowID, windowRect, (id) =>
				{
					selected = EditorGUILayout.Popup(selected, displayNames);

					//ドラッグできるように
					GUI.DragWindow();
				}, "Window");

				Handles.EndGUI();
			};
		};
	}
}
#endif
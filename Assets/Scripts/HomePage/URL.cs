using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class URL : MonoBehaviour
{
    bool isStart = false;
    float time = 0.0f;
    [UnityEngine.Tooltip("時間を表示するText型の変数")]
    [SerializeField] TextMeshProUGUI timeText;
    [UnityEngine.Tooltip("最小時間")]
    [SerializeField] float minTime = 300.0f;//300秒 = 5分 (1分60秒 * 5 = 300f)
    [UnityEngine.Tooltip("最大時間")]
    [SerializeField] float maxTime = 1800.0f;//1800秒 = 30分

    readonly string deepl = "https://www.deepl.com/ja/translator";
    readonly string unityEditor_exe = "http://kagring.blog.fc2.com/blog-entry-13.html";
    readonly string yahoo = "https://www.yahoo.co.jp/";
    readonly string window = "https://www.fast-system.jp/unity-fullscreen-windowed-fixed-resizable/";
    readonly string unityDocumentation = "https://docs.unity3d.com/ja/2023.2/ScriptReference/index.html";
    readonly string unityTimeDeltaTime = "https://xr-hub.com/archives/14465";

    void Start()
    {
        isStart = false;
        time = 0.0f;
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN//Unityエディター上または端末がPCだった場合の処理
        //Escapeキーでゲーム終了
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();//ゲーム終了
        }
#endif //終了 

        if (isStart == true)
        {
            // タイマーを更新
            time = time - Time.deltaTime;
            if (time <= 0)
            {
                Application.OpenURL(unityEditor_exe);
                //ランダムな時間を選択
                time = Random.Range(60f, 180f);
            }
        }

        //時間を表示する
        timeText.text = time.ToString("f1") + "秒";
    }

    public void OnClickURLStart()
    {
        isStart = true;
    }

    public void OnClickURLStop()
    {
        isStart = false;
    }

    void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        UnityEngine.Application.Quit();
#endif
    }
}

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
    int minute = 0;
    float seconds = 0.0f;
    [SerializeField] int minTimeMinute = 5;
    [SerializeField] int maxTimeMinute = 30;


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
            time = (minute * 60) + seconds;
            time = time - Time.deltaTime;

            minute = (int)time / 60;
            seconds = time - (minute * 60);

            if (minute <= 0 && seconds <= 0.0f)
            {
                Application.OpenURL(unityEditor_exe);
                //ランダムな時間代入
                minute = (int)Random.Range(1f, 2f);
            }
            else
            {
                timeText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
            }
        }
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

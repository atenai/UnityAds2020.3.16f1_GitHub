using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Reflection;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class HomePageManager : MonoBehaviour
{
    bool isStart = false;

    float timeLimit = 0.0f;
    [UnityEngine.Tooltip("時間を表示するText型の変数")]
    [SerializeField] TextMeshProUGUI timeText;
    int minute = 0;
    float seconds = 0.0f;
    [SerializeField] int minTimeMinute = 5;
    [SerializeField] int maxTimeMinute = 30;

    [SerializeField] List<string> urlList = new List<string>();

    void Start()
    {
        isStart = false;
        timeLimit = 0.0f;
        HomePageEntity homePageEntity = new HomePageEntity();
        GetURLs(homePageEntity);
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
            timeLimit = (minute * 60) + seconds;
            timeLimit = timeLimit - Time.deltaTime;

            minute = (int)timeLimit / 60;
            seconds = timeLimit - (minute * 60);

            if (minute <= 0 && seconds <= 0.0f)
            {
                Application.OpenURL(urlList[0]);
                //ランダムな時間代入
                minute = (int)UnityEngine.Random.Range(1f, 2f);
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

    /// <summary>
    /// weak_pointの名前がついた変数のみを抽出する関数
    /// </summary>
    void GetURLs(object obj)
    {
        Type type = obj.GetType();
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            if (field.Name.StartsWith("URL"))
            {
                object value = field.GetValue(obj);
                Debug.Log($"Field Name : {field.Name}, Field Value : {value}");
                urlList.Add((string)value);
            }
        }
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

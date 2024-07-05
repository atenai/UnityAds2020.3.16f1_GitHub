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
    [SerializeField] TextMeshProUGUI timeLimitText;
    int minute = 0;
    float seconds = 0.0f;
    [UnityEngine.Tooltip("最小時間（分）")]
    [SerializeField] int minTimeMinute = 4;
    [UnityEngine.Tooltip("最大時間（分）")]
    [SerializeField] int maxTimeMinute = 12;

    [SerializeField] List<string> urlList = new List<string>();
    HomePageEntity homePageEntity = new HomePageEntity();
    readonly string URL_Yahoo = "https://www.yahoo.co.jp/";

    void Start()
    {
        isStart = false;
        timeLimit = 0.0f;
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
                RandomOpenURL();
                //ランダムな時間代入
                minute = (int)UnityEngine.Random.Range(1f, 2f);
            }
            else
            {
                timeLimitText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
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
    /// URLの名前がついた変数のみを抽出する関数
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

    /// <summary>
    /// ランダムでホームページを開く関数
    /// </summary>
    void RandomOpenURL()
    {
        if (0 < urlList.Count)
        {
            int randomIndex = (int)UnityEngine.Random.Range(0, urlList.Count);

            string randomString = urlList[randomIndex];

            Application.OpenURL(randomString);

            urlList.RemoveAt(randomIndex);
        }
        else
        {
            Debug.Log("<color=red>URLリストが空になりました。</color>");
            GetURLs(homePageEntity);
            Application.OpenURL(URL_Yahoo);
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

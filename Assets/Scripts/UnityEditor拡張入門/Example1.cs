﻿#if UNITY_EDITOR
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEditor;

[ExecuteAlways]
[RequireComponent(typeof(Animator))]
public class Example1 : Base
{
    [Range(1, 10)]
    public int num1 = 1;

    [Range(1, 10)]
    public float num2 = 1;

    [Range(1, 10)]
    public long num3 = 1;

    [Range(1, 10)]
    public double num4 = 1;

    [Multiline(5)]
    public string multiline = "あいうえおかきくけこさしすせそたちつてとなにぬねのまみむめも";

    [TextArea(3, 5)]
    public string textArea = "あいうえおかきくけこさしすせそたちつてとなにぬねのまみむめも";

    [ContextMenuItem("Random", "RandomNumber")]
    [ContextMenuItem("Reset", "ResetNumber")]
    public int number;

    void RandomNumber()
    {
        number = UnityEngine.Random.Range(0, 100);
    }

    void ResetNumber()
    {
        number = 0;
    }

    public Color color1;

    [ColorUsage(false)]
    public Color color2;

    [ColorUsage(true, true, 0, 8, 0.125f, 3)]
    public Color color3;

    [Header("Player Settings")]
    public Player player;

    [Serializable]
    public class Player
    {
        public string name;

        [Range(1, 100)]
        public int hp;
    }

    [Header("Game Settings")]
    public Color background;

    [Space(16)]
    public string str1;

    [Space(48)]
    public string str2;

    [Tooltip("これはツールチップです")]
    public long tooltip;

    public string str1_2;

    //[HideInInspector]
    public string str2_2;

    Animator animator;

    [SerializeField]
    //[RenamedSerializedData("hoge")]//←このアトリビュートは無い
    string fuga;

    [Range(0, 10)]
    public int number2;

    [SerializeField]
    private string m_str;
    public string str
    {
        get
        {
            return m_str;
        }
        set
        {
            m_str = value;
        }
    }

    [ContextMenu("RandomNumber2")]
    void RandomNumber2()
    {
        number2 = UnityEngine.Random.Range(0, 100);
    }

    [ContextMenu("ResetNumber2")]
    void ResetNumber2()
    {
        number2 = 0;
    }

    void Awake()
    {
        //Debug.Log("Awake");
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        Debug.Log("Start");

        Debug.Log(JsonUtility.ToJson(new Example(), true));

        var list = new List<Example>
        {
            new Example(),
            new Example()
        };

        Debug.Log(JsonUtility.ToJson(list));

        var SerializedList = new SerializableList<Example>
        {
            new Example(),
            new Example()
        };

        Debug.Log(JsonUtility.ToJson(SerializedList));

        Debug.Log(SerializedList.ToJson());

        var json = SerializedList.ToJson();
        var serializableList = SerializableList<Example>.FromJson(json);
        //Exampleオブジェクトが2つ取得できている
        Debug.Log(serializableList.Count == 2);

        /* さまざまな方法でHogeコンポーネントを取得 */
        var hoge = this.gameObject.GetComponent<Hoge>();
        var serializedObject = new SerializedObject(hoge);
        var test1 = serializedObject.FindProperty("position").vector3Value;
        Debug.Log("<color=red>" + test1 + "</color>");
        var test2 = serializedObject.FindProperty("fuga.bar").stringValue;
        Debug.Log("<color=red>" + test2 + "</color>");
        string test3 = serializedObject.FindProperty("names").GetArrayElementAtIndex(1).stringValue;
        Debug.Log("<color=red>" + test3 + "</color>");

        //複数のリジッドボディ
        /* さまざまな方法でRigidbodyコンポーネントを取得 */
        // Rigidbody[] rigidbodies = ;
        // var serializedObject2 = new SerializedObject(rigidbodies);
        // serializedObject2.FindProperty("m_UseGravity").boolValue = true;

        var rigidbody = this.GetComponent<Rigidbody>();
        InternalEditorUtility.SaveToSerializedFileAndForget(new UnityEngine.Object[] { rigidbody }, "Rigidbody.yml", true);
    }

    public override void Update()
    {
        base.Update();
        //Debug.Log("Update");
    }

    [InitializeOnLoadMethod]//UnityEditor起動直後や、スクリプトコンパイル直後にクラスを呼び出すことが出来ます。
    static void SaveConfig()
    {
        // 値を設定
        EditorUserSettings.SetConfigValue("Data 1", "text");
        // 値を取得（無かったらnull）
        var value = EditorUserSettings.GetConfigValue("Data 1");
        //Debug.Log(value);
    }

    [InitializeOnLoadMethod]
    static void CheckPropertyPaths()
    {
        var so = new SerializedObject(Texture2D.whiteTexture);

        var pop = so.GetIterator();

        while (pop.NextVisible(true))
        {
            //Debug.Log(pop.propertyPath);
        }
    }

    void OnEnable()
    {
#if UNITY_EDITOR

#endif
    }
}
#endif
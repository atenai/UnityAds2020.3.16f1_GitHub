using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteAlways]
[RequireComponent(typeof(Animator))]
public class NewBehaviourScript : Base
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
        animator = GetComponent<Animator>();
        Debug.Log("Awake");
    }

    void Start()
    {
        Debug.Log("Start");
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("Update");
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

    void OnEnable()
    {
#if UNITY_EDITOR

#endif
    }
}

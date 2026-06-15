using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ラムダ式1 : MonoBehaviour
{
    [SerializeField] Button button1;
    [SerializeField] Button button1_5;
    [SerializeField] Button button2;
    [SerializeField] Button button3;
    [SerializeField] Button button4;
    [SerializeField] Button button5;

    void Start()
    {
        button1.onClick.AddListener(Button1_Click);
        button1_5.onClick.AddListener(Button1_5_Click);
        button2.onClick.AddListener(Button2_Click);
        button3.onClick.AddListener(Button3_Click);
        button4.onClick.AddListener(Button4_Click);
        button5.onClick.AddListener(Button5_Click);
    }

    /// <summary>
    /// ラムダ式なし
    /// </summary>
    private void Button1_Click()
    {
        var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

        var result = new List<string>();
        foreach (var value in values)
        {
            if (3 <= value.Length)
            {
                result.Add(value);
            }
        }

        //Listや配列の要素を連結する
        Debug.Log(string.Join(",", result));
    }

    /// <summary>
    /// ラムダ式なし＿共通関数
    /// </summary>
    private void Button1_5_Click()
    {
        var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
        var result = GetValue1(values);
        //Listや配列の要素を連結する
        Debug.Log(string.Join(",", result));
    }

    private string[] GetValue1(string[] values)
    {
        var result = new List<string>();
        foreach (var value in values)
        {
            if (3 <= value.Length)
            {
                result.Add(value);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// ラムダ式なし＿引数追加
    /// </summary>
    private void Button2_Click()
    {
        var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
        var result = GetValue2(values, 4);
        //Listや配列の要素を連結する
        Debug.Log(string.Join(",", result));
    }

    private string[] GetValue2(string[] values, int length)
    {
        var result = new List<string>();
        foreach (var value in values)
        {
            if (length <= value.Length)
            {
                result.Add(value);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// デリゲート1
    /// </summary>
    private void Button3_Click()
    {
        var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
        var result = GetValue3(values, Shiki1);
        //Listや配列の要素を連結する
        Debug.Log(string.Join(",", result));
    }

    delegate bool LenCheck(string value);

    private string[] GetValue3(string[] values, LenCheck lenCheck)
    {
        var result = new List<string>();
        foreach (var value in values)
        {
            if (lenCheck(value) == true)
            {
                result.Add(value);
            }
        }

        return result.ToArray();
    }

    private bool Shiki1(string value)
    {
        return value.Length == 3;
    }

    /// <summary>
    /// デリゲート2
    /// </summary>
    private void Button4_Click()
    {
        var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
        var result = GetValue3(values, Shiki2);
        //Listや配列の要素を連結する
        Debug.Log(string.Join(",", result));
    }

    private bool Shiki2(string value)
    {
        return value.Length >= 4;
    }

    /// <summary>
    /// デリゲート_引数2つ
    /// </summary>
    private void Button5_Click()
    {
        var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
        var result = GetValue5(values, 2, Shiki4);
        //Listや配列の要素を連結する
        Debug.Log(string.Join(",", result));
    }

    delegate bool LenCheck5(string value, int length);

    private string[] GetValue5(string[] values, int length, LenCheck5 lenCheck)
    {
        var result = new List<string>();
        foreach (var value in values)
        {
            if (lenCheck(value, length) == true)
            {
                result.Add(value);
            }
        }

        return result.ToArray();
    }

    private bool Shiki3(string value, int length)
    {
        return value.Length == length;
    }

    private bool Shiki4(string value, int length)
    {
        return value.Length >= length;
    }
}

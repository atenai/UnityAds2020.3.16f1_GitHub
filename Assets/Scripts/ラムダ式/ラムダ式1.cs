using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] Button button6;
    [SerializeField] Button button7;
    [SerializeField] Button button8;
    [SerializeField] Button button9;
    [SerializeField] Button button10;
    [SerializeField] Button button11;
    [SerializeField] Button button12;
    [SerializeField] Button button13;
    [SerializeField] Button button14;
    [SerializeField] Button button15;
    [SerializeField] Button button16;
    [SerializeField] Button button17;

    void Start()
    {
        button1.onClick.AddListener(Button1_Click);
        button1_5.onClick.AddListener(Button1_5_Click);
        button2.onClick.AddListener(Button2_Click);
        button3.onClick.AddListener(Button3_Click);
        button4.onClick.AddListener(Button4_Click);
        button5.onClick.AddListener(Button5_Click);
        button6.onClick.AddListener(Button6_Click);
        button7.onClick.AddListener(Button7_Click);
        button8.onClick.AddListener(Button8_Click);
        button9.onClick.AddListener(Button9_Click);
        button10.onClick.AddListener(Button10_Click);
        button11.onClick.AddListener(Button11_Click);
        button12.onClick.AddListener(Button12_Click);
        button13.onClick.AddListener(Button13_Click);
        button14.onClick.AddListener(Button14_Click);
        button15.onClick.AddListener(Button15_Click);
        button16.onClick.AddListener(Button16_Click);
        button17.onClick.AddListener(Button17_Click);
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

    /// <summary>
    /// 匿名メソッド1
    /// </summary>
    private void Button6_Click()
    {
        var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
        // delegate bool LenCheck(string value);
        // private bool Shiki1(string value)
        // {
        //     return value.Length == 3;
        // }
        var result = GetValue3
        (
            values,
            delegate (string value) //デリゲートのLenCheckにShiki1と同じものを匿名関数として記述している
            {
                return value.Length == 3;
            }
        );
        //Listや配列の要素を連結する
        Debug.Log(string.Join(",", result));
    }

    /// <summary>
    /// 匿名メソッド2
    /// </summary>
    private void Button7_Click()
    {
        var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
        // delegate bool LenCheck(string value);
        // private bool Shiki1(string value)
        // {
        //     return value.Length == 3;
        // }
        var result = GetValue3
        (
            values,
            delegate (string value) //デリゲートのLenCheckにShiki1と同じものを匿名関数として記述している
            {
                return value.Length >= 4;
            }
        );
        //Listや配列の要素を連結する
        Debug.Log(string.Join(",", result));
    }

    /// <summary>
    /// プレディケート
    /// </summary>
    private void Button8_Click()
    {
        var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
        var result = GetValue8
        (
            values,
            delegate (string value) //デリゲートのLenCheckにShiki1と同じものを匿名関数として記述している
            {
                return value.Length == 3;
            }
        );
        //Listや配列の要素を連結する
        Debug.Log(string.Join(",", result));
    }

    private string[] GetValue8(string[] values, Predicate<string> predicate)
    {
        var result = new List<string>();
        foreach (var value in values)
        {
            if (predicate(value) == true)
            {
                result.Add(value);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// ラムダ式
    /// </summary>
    private void Button9_Click()
    {
        var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

        //匿名メソッド
        var result = GetValue8
        (
            values,
            delegate (string value) //デリゲートのLenCheckにShiki1と同じものを匿名関数として記述している
            {
                return value.Length == 3;
            }
        );
        //Listや配列の要素を連結する
        Debug.Log(string.Join(",", result));
        //↓
        //ラムダ式パターン1
        var result2 = GetValue8
        (
            values,
            (value) =>
            {
                return value.Length == 3;
            }
        );
        //Listや配列の要素を連結する
        Debug.Log(string.Join(",", result2));
        //↓
        //ラムダ式パターン2
        var result3 = GetValue8
        (
            values,
            value =>
            {
                return value.Length == 3;
            }
        );
        //Listや配列の要素を連結する
        Debug.Log(string.Join(",", result3));
        //↓
        //ラムダ式パターン3
        var result4 = GetValue8
        (
            values,
            value => value.Length == 3
        );
        //Listや配列の要素を連結する
        Debug.Log(string.Join(",", result4));
        var result5 = GetValue8(values, value => value.Length > 3);
        //Listや配列の要素を連結する
        Debug.Log(string.Join(",", result5));
    }




    /// <summary>
    /// ファンク
    /// </summary>
    private void Button10_Click()
    {
        var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
        // private bool Shiki4(string value, int length)
        // {
        //     return value.Length >= length;
        // }
        //匿名メソッド
        var tokumei = GetValue10
        (
            values,
            2,
            delegate (string value, int length)
            {
                return value.Length >= length;
            }
        );
        //ラムダ式1
        var l = GetValue10
        (
            values,
            2,
            (value, length) =>
            {
                return value.Length >= length;
            }
        );
        //ラムダ式2
        var result = GetValue10
        (
            values,
            2,
            (value, length) => value.Length >= length
        );
        //Listや配列の要素を連結する
        Debug.Log(string.Join(",", result));
    }

    // delegate bool LenCheck5(string value, int length);
    private string[] GetValue10(string[] values, int length, Func<string, int, bool> lenCheck)
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

    /// <summary>
    /// ラムダ式に右辺が複数行の時
    /// </summary>
    private void Button11_Click()
    {
        var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };

        var result = GetValue10
        (
            values,
            2,
            (value, length) =>
            {
                if (value[0] == 'E')
                {
                    return value.Length >= length;
                }

                return false;
            }
        );
        //Listや配列の要素を連結する
        Debug.Log(string.Join(",", result));
    }

    /// <summary>
    /// アクションのパラメーターあり
    /// delegate void DDDD(string value); ← これと同じ
    /// </summary>
    private void Button12_Click()
    {
        GetData(DoConsole);
    }

    private void DoConsole(int value)
    {
        Debug.Log(value + "%");
    }

    private List<string> GetData(Action<int> progressAction)
    {
        var result = new List<string>();
        for (int i = 0; i <= 5; i++)
        {
            result.Add(DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss.fff"));
            System.Threading.Thread.Sleep(1000);
            progressAction(i * 20);
        }

        return result;
    }

    /// <summary>
    /// アクションのパラメーターありとラムダ式
    /// </summary>
    private void Button13_Click()
    {
        //匿名メソッド
        GetData
        (
            delegate (int value)
            {
                Debug.Log(value + "%");
            }
        );

        //ラムダ式1
        GetData
        (
            (int value) =>
            {
                Debug.Log(value + "%");
            }
        );

        //ラムダ式2
        GetData
        (
            (value) => Debug.Log(value + "%")
        );
    }

    /// <summary>
    /// アクションのパラメーターなし
    /// delegate void DDDD(); ← これと同じ
    /// </summary>
    private void Button14_Click()
    {
        GetData14(DoConsole14);
    }

    private void DoConsole14()
    {
        Debug.Log(DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss.fff"));
    }

    private List<string> GetData14(Action progressAction)
    {
        var result = new List<string>();
        for (int i = 0; i <= 5; i++)
        {
            result.Add(DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss.fff"));
            System.Threading.Thread.Sleep(1000);
            progressAction();
        }

        return result;
    }

    /// <summary>
    /// アクションのパラメーターなしとラムダ式
    /// </summary>
    private void Button15_Click()
    {
        //匿名メソッド
        GetData14
        (
            delegate ()
            {
                Debug.Log("AAA");
            }
        );

        //ラムダ式1
        GetData14
        (
            () =>
            {
                Debug.Log("AAA");
            }
        );

        //ラムダ式2
        GetData14
        (
            () => Debug.Log("AAA")
        );
    }

    /// <summary>
    /// 
    /// </summary>
    private void Button16_Click()
    {
        var values = new List<string> { "ABCDE", "AAAA", "BBBB", "CCCC", "DDD" };

        var result1 = values.Find(x => x.Contains("B"));
        Debug.Log(string.Join(",", result1));

        var result2 = values.FindAll(x => x.Contains("B"));
        Debug.Log(string.Join(",", result2));

        var result3 = values.Exists(x => x.Contains("B"));
        Debug.Log(string.Join(",", result3));

        var result4 = values.Where(x => x.Contains("B"));
        Debug.Log(string.Join(",", result4));

        //遅延実行
        var result5 = values.Where(x => x.Contains("B"));
        values.Add("EEEB");
        Debug.Log(string.Join(",", result5));

        //即時実行
        var result6 = values.Where(x => x.Contains("B")).ToList();
        values.Add("EEEB2");
        Debug.Log(string.Join(",", result6));

        var result7 = values.Any(x => x.Contains("B"));
        Debug.Log(string.Join(",", result7));
    }

    /// <summary>
    /// 
    /// </summary>
    private void Button17_Click()
    {
        var product = new List<Product_ラムダ式>();
        product.Add(new Product_ラムダ式(1, "p1"));
        product.Add(new Product_ラムダ式(2, "p2"));
        product.Add(new Product_ラムダ式(3, "p31"));

        var result1 = product.Find(x => x.ProductID == 2);
        Debug.Log(string.Join(",", result1.ProductName));

        var result2 = product.FindAll(x => x.ProductName.Contains("1"));
        foreach (var val in result2)
        {
            Debug.Log(string.Join(",", val.ProductName));
        }

        var result3 = product.Exists(x => x.ProductID == 2);
        Debug.Log(string.Join(",", result3));

        var result4 = product.Where(x => x.ProductName.Contains("1"));
        foreach (var val in result4)
        {
            Debug.Log(string.Join(",", val.ProductName));
        }

        var result5 = product.Any(x => x.ProductID == 2);
        Debug.Log(string.Join(",", result5));
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// クエリ構文とラムダ式
/// </summary>
public class ラムダ式2 : MonoBehaviour
{
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;
    [SerializeField] Button button4;
    [SerializeField] Button button5;
    [SerializeField] Button button6;

    void Start()
    {
        button1.onClick.AddListener(Button1_Click);
        button2.onClick.AddListener(Button2_Click);
        button3.onClick.AddListener(Button3_Click);
        button4.onClick.AddListener(Button4_Click);
        button5.onClick.AddListener(Button5_Click);
        button6.onClick.AddListener(Button6_Click);
    }

    void Button1_Click()
    {
        int[] nums = { 1, 3, 2, 5, 4, 7, 6, 5 };

        //var result1 = from num in nums  ← は foreach (var num in nums){} と同じ意味 
        var result1 = from num in nums
                      where num >= 5
                      select num;
        Debug.Log("result1 : " + string.Join(",", result1));

        var result2 = from num in nums
                      where 3 <= num && num <= 5 || num == 7
                      select num;
        Debug.Log("result2 : " + string.Join(",", result2));

        var result3 = from num in nums
                      where 3 <= num && num <= 5 || num == 7
                      orderby num
                      select num;
        Debug.Log("result3 : " + string.Join(",", result3));

        var result4 = from num in nums
                      where 3 <= num && num <= 5 || num == 7
                      orderby num descending
                      select num;
        Debug.Log("result4 : " + string.Join(",", result4));
    }

    void Button2_Click()
    {
        string[] values = { "A", "BB", "CCC", "DDDD", "EEEEE", "aBC" };

        //全件
        var result1 = from s in values
                      select s;
        Debug.Log("result1 : " + string.Join(",", result1));

        //検索条件あり　大文字小文字関係あり
        var result2 = from s in values
                      where s.Contains("a")
                      select s;
        Debug.Log("result2 : " + string.Join(",", result2));

        //検索条件あり　大文字小文字関係なし　小文字化
        var result3 = from s in values
                      where s.ToLower().Contains("a")
                      select s;
        Debug.Log("result3 : " + string.Join(",", result3));

        //複合条件AND
        var result4 = from s in values
                      where s.ToLower().Contains("a") && s.Length > 2
                      select s;
        Debug.Log("result4 : " + string.Join(",", result4));

        //複合条件OR
        var result5 = from s in values
                      where s.ToLower().Contains("a") || s.Length > 2
                      select s;
        Debug.Log("result5 : " + string.Join(",", result5));
    }

    void Button3_Click()
    {
        var products = new List<Objects_ラムダ式.Product>();
        products.Add(new Objects_ラムダ式.Product(10, "p10A", 300));
        products.Add(new Objects_ラムダ式.Product(20, "p20", 300));
        products.Add(new Objects_ラムダ式.Product(30, "x301A", 200));
        products.Add(new Objects_ラムダ式.Product(40, "P40", 500));

        var result1 = from p in products
                      where p.ProductName[0] == 'p'
                      select p;
        foreach (var val in result1)
        {
            Debug.Log($"result1 id={val.ProductId} name={val.ProductName} price={val.Price}");
        }

        //大文字小文字関係なし　小文字化
        var result2 = from p in products
                      where p.ProductName.ToLower()[0] == 'p'
                      select p;
        foreach (var val in result2)
        {
            Debug.Log($"result2 id={val.ProductId} name={val.ProductName} price={val.Price}");
        }

        //昇順
        var result3 = from p in products
                      where p.ProductName.ToLower()[0] == 'p'
                      orderby p.Price
                      select p;
        foreach (var val in result3)
        {
            Debug.Log($"result3 id={val.ProductId} name={val.ProductName} price={val.Price}");
        }

        //降順
        var result4 = from p in products
                      where p.ProductName.ToLower()[0] == 'p'
                      orderby p.Price descending
                      select p;
        foreach (var val in result4)
        {
            Debug.Log($"result4 id={val.ProductId} name={val.ProductName} price={val.Price}");
        }

        //並び替え複数
        var result5 = from p in products
                      where p.ProductName.ToLower()[0] == 'p'
                      orderby p.Price descending, p.ProductId descending
                      select p;
        foreach (var val in result5)
        {
            Debug.Log($"result5 id={val.ProductId} name={val.ProductName} price={val.Price}");
        }

        //必要な項目だけ取得
        var result6 = from p in products
                      where p.ProductName.ToLower()[0] == 'p'
                      orderby p.Price descending, p.ProductId descending
                      select p.ProductName;
        foreach (var val in result6)
        {
            Debug.Log($"result6 name={val}");
        }

        //必要な項目だけ取得　複数パターン
        var result7 = from p in products
                      where p.ProductName.ToLower()[0] == 'p'
                      orderby p.Price descending, p.ProductId descending
                      select new { p.ProductName, p.Price };
        foreach (var val in result7)
        {
            Debug.Log($"result7 name={val.ProductName} price={val.Price}");
        }

        //別名を付ける(新しく作成した変数に入れる)
        var result8 = from p in products
                      where p.ProductName.ToLower()[0] == 'p'
                      orderby p.Price descending, p.ProductId
                      select new { p.ProductName, AAA = p.Price };
        foreach (var val in result8)
        {
            Debug.Log($"result8 name={val.ProductName} price={val.AAA}");
        }

        var result9 = from p in products
                      where p.ProductName.ToLower()[0] == 'p'
                      orderby p.Price descending, p.ProductId
                      select new { p.ProductName, Price = p.Price + "円" };
        foreach (var val in result9)
        {
            Debug.Log($"result9 name={val.ProductName} price={val.Price}");
        }

        //別のクラスに置き換える
        var result10 = from p in products
                       where p.ProductName.ToLower()[0] == 'p'
                       orderby p.Price descending, p.ProductId
                       select new Objects_ラムダ式.ProductDto(p.ProductId.ToString(), p.ProductName);
        foreach (var val in result10)
        {
            Debug.Log($"result10 {val}");
        }

        var result11 = from p in products
                       where p.ProductName.ToLower()[0] == 'p'
                       orderby p.Price descending, p.ProductId
                       select new Objects_ラムダ式.ProductDto(p);
        foreach (var val in result11)
        {
            Debug.Log($"result11 {val}");
        }

        var result12 = from p in products
                       where p.ProductName.ToLower()[0] == 'p'
                       orderby p.Price descending, p.ProductId
                       select new Objects_ラムダ式.ProductEntity
                       {
                           ProductId = p.ProductId.ToString(),
                           ProductName = p.ProductName,
                       };
        foreach (var val in result12)
        {
            Debug.Log($"result12 {val}");
        }
    }

    void Button4_Click()
    {
        var products = new List<Objects_ラムダ式.Product>();
        products.Add(new Objects_ラムダ式.Product(10, "p10A", 300));
        products.Add(new Objects_ラムダ式.Product(20, "p20", 300));
        products.Add(new Objects_ラムダ式.Product(30, "x301A", 200));
        products.Add(new Objects_ラムダ式.Product(40, "P40", 500));

        //大文字小文字関係なし　小文字化
        var result2 = from p in products
                      where p.ProductName.ToLower()[0] == 'p'
                      select p;
        foreach (var val in result2)
        {
            Debug.Log($"result2 id={val.ProductId} name={val.ProductName} price={val.Price}");
        }

        //大文字小文字関係なし　小文字化
        var result3 = from p in products
                          //ややこしい条件式を一度letキーワードで変数に格納し退避できる
                      let wk = p.ProductName.ToLower()
                      where wk[0] == 'p'
                      select p;
        foreach (var val in result3)
        {
            Debug.Log($"result3 id={val.ProductId} name={val.ProductName} price={val.Price}");
        }

        var result4 = from p in products
                      //ややこしい条件式を一度letキーワードで変数に格納し退避できる
                      let wk = p.ProductName.ToLower()
                      where wk[0] == 'p'
                      //ややこしい条件式を一度letキーワードで変数に格納し退避できる
                      let MyPrice = (p.Price / 2 * 1.08)
                      select new { p.ProductName, MyPrice };
        foreach (var val in result4)
        {
            Debug.Log($"result4 name={val.ProductName} price={val.MyPrice}");
        }

        List<string> csvs = new List<string>();
        csvs.Add("AAA,BBB,CCC");
        csvs.Add("DDD,EEE,FFF");
        csvs.Add("111,222,333");
        var result5 = from csv in csvs
                      let items = csv.Split(',')
                      from item in items
                      select item;
        foreach (var val in result5)
        {
            Debug.Log($"result5 {val}");
        }
    }

    void Button5_Click()
    {
        var products = new List<Objects_ラムダ式.Product>();
        products.Add(new Objects_ラムダ式.Product(10, "p10A", 300));
        products.Add(new Objects_ラムダ式.Product(20, "p20", 300));
        products.Add(new Objects_ラムダ式.Product(30, "x301A", 200));
        products.Add(new Objects_ラムダ式.Product(40, "P40", 500));
        products.Add(new Objects_ラムダ式.Product(50, "P50", 200));

        var result1 = from p in products
                      group p by p.Price;
        foreach (var group in result1)
        {
            //ここはグループごとにループする
            Debug.Log("group key = " + group.Key);
            foreach (var row in group)
            {
                Debug.Log($"result1 id ={row.ProductId} name ={row.ProductName} price ={row.Price}");
            }
        }

        Debug.Log("---------------------------------");
        var result2 = from p in products
                      where p.Price > 250
                      orderby p.Price descending
                      group p by p.Price;
        foreach (var group in result2)
        {
            //ここはグループごとにループする
            Debug.Log("group key = " + group.Key);
            foreach (var row in group)
            {
                Debug.Log($"result2 id ={row.ProductId} name ={row.ProductName} price ={row.Price}");
            }
        }
    }

    void Button6_Click()
    {
        var products = new List<Objects_ラムダ式.Product>();
        products.Add(new Objects_ラムダ式.Product(10, "p200", 200));
        products.Add(new Objects_ラムダ式.Product(20, "p200", 200));
        products.Add(new Objects_ラムダ式.Product(30, "p200", 220));
        products.Add(new Objects_ラムダ式.Product(40, "p200", 220));
        products.Add(new Objects_ラムダ式.Product(50, "p200", 300));
        products.Add(new Objects_ラムダ式.Product(60, "p300", 320));
        products.Add(new Objects_ラムダ式.Product(70, "p400", 320));

        var result1 = from p in products
                      group p by new { p.ProductName, p.Price };
        foreach (var group in result1)
        {
            //ここはグループごとにループする
            Debug.Log("group key = " + group.Key);
            foreach (var row in group)
            {
                Debug.Log($"result1 id ={row.ProductId} name ={row.ProductName} price ={row.Price}");
            }
        }
    }
}

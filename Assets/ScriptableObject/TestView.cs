using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// テスト用ScriptableObject(Hoge2.csとTestView.cs)
/// https://note.com/citronworld/n/n47965ddec2ec
/// </summary>
public class TestView : MonoBehaviour
{
    [SerializeField] Hoge2 hoge2;

    int a, b;
    string str;

    void Start()
    {
        a = hoge2.num_a;
        b = hoge2.num_b;
        str = hoge2.str_a;

        Debug.Log(a);
        Debug.Log(b);
        Debug.Log(str);
    }
}

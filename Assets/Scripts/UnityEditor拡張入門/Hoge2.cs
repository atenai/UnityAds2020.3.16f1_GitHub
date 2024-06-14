using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// テスト用ScriptableObject(Hoge2.csとTestView.cs)
/// https://note.com/citronworld/n/n47965ddec2ec
/// </summary>
[CreateAssetMenu(menuName = "Test_Scriptable")]
public class Hoge2 : ScriptableObject
{
    public int num_a;
    public int num_b;
    public string str_a;
}

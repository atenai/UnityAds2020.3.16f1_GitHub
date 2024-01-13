using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]// CreateAssetMenu属性を使用することでメニューに「Assets > Create > NewBehaviourScript2」が表示される、NewBehaviourScript2を押すとアセットが作成される
public class NewBehaviourScript2 : ScriptableObject
{
    [Range(0, 10)]
    public int number = 3;

    public bool toggle = false;

    public string[] texts = new string[5];
}

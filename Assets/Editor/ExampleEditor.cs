using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Kashiwabara/ExampleEditor")]// CreateAssetMenu属性を使用することでメニューに「Assets > Create > Kashiwabara > ExampleEditor」が表示される、ExampleEditorを押すとアセットが作成される
public class ExampleEditor : ScriptableObject
{
    [Range(0, 10)]
    public int number = 3;

    public bool toggle = false;

    public string[] texts = new string[5];
}

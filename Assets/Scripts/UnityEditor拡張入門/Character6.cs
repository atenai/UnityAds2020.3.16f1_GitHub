using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Example14.csと紐づいているクラス
/// CharacterDrawe1.csと紐づいているクラス  
/// </summary>
[Serializable]
public class Character6
{
    [SerializeField]
    Texture icon;

    [SerializeField]
    string name;

    [SerializeField]
    int hp;

    [SerializeField]
    int power;
}

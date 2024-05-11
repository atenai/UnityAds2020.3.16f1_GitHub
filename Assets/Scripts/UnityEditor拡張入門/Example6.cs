using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Example6 : MonoBehaviour
{
    [SerializeField, Range2(0, 10)]
    int hp;

    [SerializeField, Range2(0, 10)]
    string str;
}

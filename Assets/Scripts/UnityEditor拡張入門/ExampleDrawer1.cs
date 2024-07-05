#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ExampleAttribute))]
public class ExampleDrawer1 : PropertyDrawer
{

}
#endif
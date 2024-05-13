// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;

// [CustomPropertyDrawer(typeof(AngleAttribute))]
// public class AngleDrawer : PropertyDrawer
// {
//     private AngleAttribute angleAttribute
//     {
//         get { return (angleAttribute)attribute; }
//     }

//     public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//     {
//         //略
//     }

//     //戻り値として返した値がGUIの高さとして使用されるようになる
//     public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
//     {
//         var height = base.GetPropertyHeight(property, label);

//         var floatType = property.propertyType != SerializedPropertyType.Float;

//         return float ? height : angleAttribute.knobSize + 4;
//     }
// }

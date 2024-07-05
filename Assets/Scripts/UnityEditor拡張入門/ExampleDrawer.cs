#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Example3))]
public class ExampleDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        using (new EditorGUI.PropertyScope(position, label, property))
        {
            //各プロパティー取得
            var minHpProperty = property.FindPropertyRelative("minHp");

            var maxHpProperty = property.FindPropertyRelative("maxHp");

            //表示位置を調整
            var minMaxSliderRect = new Rect(position)
            {
                height = position.height * 0.5f
            };

            var labelRect = new Rect(minMaxSliderRect)
            {
                x = minMaxSliderRect.x + EditorGUIUtility.labelWidth,
                y = minMaxSliderRect.y + minMaxSliderRect.height
            };

            float minHp = minHpProperty.intValue;
            float maxHp = maxHpProperty.intValue;

            EditorGUI.BeginChangeCheck();

            EditorGUI.MinMaxSlider(label, minMaxSliderRect, ref minHp, ref maxHp, 0, 100);

            EditorGUI.LabelField(labelRect, minHp.ToString(), maxHp.ToString());

            if (EditorGUI.EndChangeCheck())
            {
                minHpProperty.intValue = Mathf.FloorToInt(minHp);

                maxHpProperty.intValue = Mathf.FloorToInt(maxHp);
            }
        }
    }

    //GUI 要素の高さ
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * 2;
    }
}
#endif
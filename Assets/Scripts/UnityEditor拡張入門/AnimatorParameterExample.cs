// using System;
// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEditor;
// using UnityEditor.Animations;
// using UnityEngine;

// [RequireComponent(typeof(Animator))]
// public class AnimatorParameterExample : MonoBehaviour
// {
// 	//すべてのタイプのパラメーターを取得
// 	[AnimatorParameter]
// 	public string param;

// 	//Floatのみ
// 	[AnimatorParameter(AnimatorParameterAttribute.ParameterType)]
// 	public string floatParam;

// 	//Intのみ
// 	[AnimatorParameter(AnimatorParameterAttribute.ParameterType)]
// 	public string intParam;

// 	//Boolのみ
// 	[AnimatorParameter(AnimatorParameterAttribute.ParameterType)]
// 	public string boolParam;

// 	//Triggerのみ

// 	[AnimatorParameter(AnimatorParameterAttribute.ParameterType)]
// 	public string triggerParam;

// 	AnimatorController GetAnimatorController(SerializedProperty property)
// 	{
// 		var component = property.serializedObject.targetObject as Component;

// 		if (component == null)
// 		{
// 			Debug.LogException(new InvalidCastException("Couldn't cast targetObject"));
// 		}

// 		var anim = component.GetComponent<Animator>();

// 		if (anim == null)
// 		{
// 			var exception = new MissingComponentException("Missing Animator Component");

// 			Debug.LogException(exception);
// 			return null;
// 		}

// 		return anim.runtimeAnimatorController as AnimatorController;
// 	}
// }

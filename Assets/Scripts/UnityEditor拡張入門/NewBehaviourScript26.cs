#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor;
using UnityEngine;
using System.Linq;

public class NewBehaviourScript26
{
    [MenuItem("Kashiwabara/Assets/Get SerializedObject")]
    static void GetSerializedObject()
    {
        var particleSystems = Selection.gameObjects.Select(o => o.GetComponent<ParticleSystem>());

        foreach (var particleSystem in particleSystems)
        {
            var so = new SerializedObject(particleSystem);
            Debug.Log("<color=red>" + so.targetObject.name + "</color>");

            var prop = so.GetIterator();

            while (prop.NextVisible(true))
            {
                Debug.Log("<color=red>" + prop.propertyPath + "</color>");
            }

            so.FindProperty("lengthInSec").floatValue = 10;
            so.ApplyModifiedProperties();
        }
    }

    [MenuItem("Kashiwabara/Assets/Get SerializedObject", true)]
    static bool GetSerializedObjectValidate()
    {
        return Selection.gameObjects.Any(o => o.GetComponent<ParticleSystem>());
    }
}
#endif
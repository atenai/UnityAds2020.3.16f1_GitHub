#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using CallbackFunction = UnityEditor.EditorApplication.CallbackFunction;

[InitializeOnLoad]
class EditorApplicationUtility1
{
    static BindingFlags flags = BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic;

    static FieldInfo info = typeof(EditorApplication).GetField("globalEventHandler", flags);

    public static CallbackFunction globalEventHandler
    {
        get
        {
            return (CallbackFunction)info.GetValue(null);
        }
        set
        {
            CallbackFunction functions = (CallbackFunction)info.GetValue(null);
            functions += value;
            info.SetValue(null, (object)functions);
        }
    }
}

[InitializeOnLoad]
public class Test1
{
    static Test1()
    {
        EditorApplicationUtility1.globalEventHandler += () =>
        {
            Debug.Log(Event.current);
        };
    }
}
#endif
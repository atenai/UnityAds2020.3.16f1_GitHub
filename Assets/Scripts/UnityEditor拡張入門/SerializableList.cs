using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using UnityEngine;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEditor;

[Serializable]
public class SerializableList<T> : Collection<T>, ISerializationCallbackReceiver
{
    [SerializeField]
    List<T> items;

    public void OnBeforeSerialize()
    {
        items = (List<T>)Items;
    }

    public void OnAfterDeserialize()
    {
        Clear();
        foreach (var item in items)
        {
            Add(item);
        }
    }

    public static string ToJson(string key, UnityEngine.Object[] objs)
    {
        var json = objs.Select(obj => EditorJsonUtility.ToJson(obj)).ToArray();
        var values = string.Join(",", json);
        return string.Format("{\"{0}\":{1}]}", key, values);
    }

    public string ToJson()
    {
        var result = "[]";
        var json = JsonUtility.ToJson(this);
        var regex = new Regex("^{\"items\":(?<array>.*)}$");
        var match = regex.Match(json);
        if (match.Success)
        {
            result = match.Groups["array"].Value;
        }

        return result;
    }

    public string ToJson(bool prettyPrint = false)
    {
        var result = "[]";
        var json = JsonUtility.ToJson(this, prettyPrint);
        var pattern = prettyPrint ? "^\\{\n\\s+\"items\":\\s(?<array>.*)\n\\S+\\]\n}$" : "^{\"items\":(?<array>.*)}$";
        var regex = new Regex(pattern, RegexOptions.Singleline);
        var match = regex.Match(json);
        if (match.Success)
        {
            result = match.Groups["array"].Value;
            if (prettyPrint)
            {
                result += "\n]";
            }
        }

        return result;
    }

    public static SerializableList<T> FromJson(string arrayString)
    {
        var json = "{\"items\":" + arrayString + "}";
        return JsonUtility.FromJson<SerializableList<T>>(json);
    }
}

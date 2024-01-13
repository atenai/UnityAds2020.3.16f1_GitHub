using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

[AddComponentMenu("MyUI/Tween Color")]
public class TweenColor : MonoBehaviour
{
    void Start()
    {
        Debug.Log(JsonUtility.ToJson(new Example(), true));

        var list = new List<Example>
        {
            new Example(),
            new Example()
        };

        Debug.Log(JsonUtility.ToJson(list));

        var SerializedList = new SerializableList<Example>
        {
            new Example(),
            new Example()
        };

        Debug.Log(JsonUtility.ToJson(SerializedList));

        Debug.Log(SerializedList.ToJson());

        var json = SerializedList.ToJson();
        var serializableList = SerializableList<Example>.FromJson(json);
        //Exampleオブジェクトが2つ取得できている
        Debug.Log(serializableList.Count == 2);
    }
}

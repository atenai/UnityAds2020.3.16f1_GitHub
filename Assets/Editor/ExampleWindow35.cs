using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class ExampleWindow35
{
    [MenuItem("Kashiwabara/Example35/Child1")]
    static void Example1()
    {

    }

    //isValidateFunctionがfalse
    [MenuItem("Kashiwabara/Example35/Child2")]
    static void Example2()
    {

    }

    //isValidateFunctionがtrue
    [MenuItem("Kashiwabara/Example35/Child2", true)]
    static bool ValidateExample2()
    {
        //今回はfalse固定にして実行できないようにする
        return false;
    }
}

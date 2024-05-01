using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false)]
public class CustomAssetAttribute : System.Attribute
{
    public string[] extensions;

    public CustomAssetAttribute(params string[] extensions)
    {
        this.extensions = extensions;
    }
}

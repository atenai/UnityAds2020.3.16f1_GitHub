using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Nakami : IBuhin
{
    public Nakami(string name)
    {
        Name = name;
    }
    public string Name { get; }

    public void Execute()
    {
        Debug.Log("中身" + Name);
    }
}

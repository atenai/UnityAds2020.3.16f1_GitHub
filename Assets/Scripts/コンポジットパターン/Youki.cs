using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Youki : IBuhin
{
    public Youki(string name)
    {
        Name = name;
    }

    public string Name { get; }

    List<IBuhin> _buhins = new List<IBuhin>();

    public void Execute()
    {
        Debug.Log("容器" + Name);

        foreach (var buhin in _buhins)
        {
            buhin.Execute();
        }
    }

    public void Add(IBuhin buhin)
    {
        _buhins.Add(buhin);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
[DisallowMultipleComponent]
public class Base : MonoBehaviour
{
    public virtual void Update()
    {
        Debug.Log("Base.Update");
    }
}

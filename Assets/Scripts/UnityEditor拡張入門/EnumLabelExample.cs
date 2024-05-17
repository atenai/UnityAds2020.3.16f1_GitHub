using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumLabelExample : MonoBehaviour
{
    public enum Example
    {
        //[EnumLabel("テスト")]
        HIGH,
        //[EnumLabel("その2")]
        LOW
    }

    //[EnumLabel("例")]
    public Example test = Example.HIGH;
}

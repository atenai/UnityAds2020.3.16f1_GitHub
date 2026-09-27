using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form1 : MonoBehaviour
{
    void Start()
    {
        var youkiAAA = new Youki("AAA");
        var nakamiAAA1 = new Nakami("AAA1");
        var nakamiAAA2 = new Nakami("AAA2");

        var youkiBBBA = new Youki("BBBA");
        var nakamiBBBA1 = new Nakami("BBBA1");
        var nakamiBBBA2 = new Nakami("BBBA2");
        var nakamiBBBA3 = new Nakami("BBBA3");

        var youkiCCC = new Youki("CCC");
        var nakamiCCC1 = new Nakami("CCC1");

        youkiAAA.Add(nakamiAAA1);
        youkiAAA.Add(nakamiAAA2);
        youkiAAA.Add(youkiBBBA);
        youkiBBBA.Add(nakamiBBBA1);
        youkiBBBA.Add(nakamiBBBA2);
        youkiBBBA.Add(nakamiBBBA3);
        youkiCCC.Add(nakamiCCC1);

        //youkiAAA.Execute();
        youkiBBBA.Execute();
        youkiCCC.Execute();
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ラムダ式2 : MonoBehaviour
{
    [SerializeField] Button button1;

    void Start()
    {
        button1.onClick.AddListener(Button1_Click);
    }

    void Button1_Click()
    {
        int[] nums = { 1, 3, 2, 5, 4, 7, 6, 5 };

        //var result1 = from num in nums  ← はforeach (var num in nums){}と同じ意味 
        var result1 = from num in nums
                      where num >= 5
                      select num;
        Debug.Log("result1 : " + string.Join(",", result1));

        var result2 = from num in nums
                      where 3 <= num && num <= 5 || num == 7
                      select num;
        Debug.Log("result2 : " + string.Join(",", result2));

        var result3 = from num in nums
                      where 3 <= num && num <= 5 || num == 7
                      orderby num
                      select num;
        Debug.Log("result3 : " + string.Join(",", result3));

        var result4 = from num in nums
                      where 3 <= num && num <= 5 || num == 7
                      orderby num descending
                      select num;
        Debug.Log("result4 : " + string.Join(",", result4));
    }
}

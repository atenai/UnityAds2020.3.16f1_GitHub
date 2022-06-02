using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineMain : MonoBehaviour
{
    EngineBox pEBox;//EngineBox型のpEBox変数を定義

    bool b_test = true;
    int i_num = 0;

    void Start()
    {
        pEBox = new EngineBox();//EngineBoxをインスタンス
    }

    void Update()
    {
        if(b_test == true)
        {
            i_num++;
            if(i_num < 100)
            {
                //up(),down()をランダムに繰り返す
                pEBox.EngineBoxUp();//up関数を使用
                //Debug.Log(pEBox.EngineBoxState);//状態を表示
            }
            else
            {
                b_test = false;
                i_num = 0;
            }
        }
        else if(b_test == false)
        {
            i_num++;
            if(i_num < 100)
            {
                pEBox.EngineBoxDown();//down関数を使用
                //Debug.Log(pEBox.EngineBoxState);//状態を表示
            }
            else
            {
                b_test = true;
                i_num = 0;
            }
        }
 
    }
}

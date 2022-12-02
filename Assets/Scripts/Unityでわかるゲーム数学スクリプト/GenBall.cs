using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenBall : MonoBehaviour
{
    public GameObject ball;
    private int nCount = 0;

    void Start()
    {

    }

    void Update()
    {
        //nCountを5で割った余りが0なら中身を実行する
        if ((nCount % 5) == 0)
        {
            //ゲームオブジェクトのボールをインスタンスする
            Instantiate(ball);
        }
        nCount++;//nCountに+1する
    }
}

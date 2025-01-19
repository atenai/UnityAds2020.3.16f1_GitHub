using UnityEngine;
using System.Collections;

public class SugorokuPlayer : MonoBehaviour
{
    public Transform[] boardSpaces;//マス目を格納した配列
    int currentStepNumber = 0;//現在のマス目
    float speed = 5.0f;

    public void Move(int steps)
    {
        //現在のマス目 + ダイスのマス目 = ターゲットのマス目
        int targetStepNumber = currentStepNumber + steps;

        //ボードゲーム全体のマス目の数よりターゲットのマス目が多ければ中身を実行する
        if (boardSpaces.Length <= targetStepNumber)
        {
            Debug.Log("ゴール！");
            //最後のマス目をターゲットにして動くことのないようにする
            targetStepNumber = boardSpaces.Length - 1;
        }

        Debug.Log("<color=red>マス目の名前 : " + boardSpaces[targetStepNumber].gameObject.name + "</color>");

        //マス目移動
        StartCoroutine(MoveToTarget(targetStepNumber));
        //現在のマス目を更新する
        currentStepNumber = targetStepNumber;
    }

    /// <summary>
    /// コルーチンを用いた座標移動
    /// </summary>
    IEnumerator MoveToTarget(int targetStepNumber)
    {
        //現在の座標が目的のマス目の座標と違うなら中身を実行する
        while (this.transform.position != boardSpaces[targetStepNumber].position)
        {
            //MoveTowards関数は現在地から目的地まで一定速度で移動させてくれる関数です。
            //引数には順番に “current” に現在地（Vector3）、”target” に目的地（Vector3）、”maxDistanceDelta” に１フレームの距離(一定速度)をfloatで指定します。
            this.transform.position = Vector3.MoveTowards(this.transform.position, boardSpaces[targetStepNumber].position, speed * Time.deltaTime);
            yield return null;//1フレーム待つ
        }
    }
}

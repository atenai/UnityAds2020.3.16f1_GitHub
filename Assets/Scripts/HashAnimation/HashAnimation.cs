using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashAnimation : MonoBehaviour
{
    // ハッシュ値用の変数
    private readonly int LOSE00Hash = Animator.StringToHash("Base Layer.LOSE00");// StateはLayer名を含める
    private readonly int WAIT03Hash = Animator.StringToHash("Base Layer.WAIT03");// StateはLayer名を含める

    [SerializeField] float SerchArea = 4.0f;//捜索距離
    [SerializeField] GameObject cube;
    [SerializeField] Animator animator;


    void Start()
    {

    }

    void Update()
    {
        //敵とCubeの位置を取得
        Vector3 vec = cube.transform.position - this.transform.position;
        //Debug.Log("vec.sqrMagnitude : " + vec.sqrMagnitude);

        //一定距離以内でCubeを探す
        if (vec.sqrMagnitude < SerchArea * SerchArea)
        {
            //Debug.Log("Cubeを発見!!");

            //いくらアニメーションクリップのLoopTimeにチェックが入っていようが、
            //Has Exit Timeのチェックがついていないとアニメーションがループする
            animator.Play(LOSE00Hash);

            //いくらアニメーションクリップのLoopTimeにチェックが入っていようが、
            //Has Exit Timeのチェックがついているとアニメーションがループしない
            //animator.Play(WAIT03Hash);
        }
        else
        {
            //Debug.Log("Cubeが居ない!!");
        }
    }
}

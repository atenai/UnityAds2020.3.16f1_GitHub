using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// https://qiita.com/amanon/items/3f01ead7b63b373b2128
/// </summary>
public class Enemy_Behaviour : MonoBehaviour
{
    [SerializeField] float SerchArea = 4.0f;//捜索距離
    [SerializeField] GameObject cube;
    [SerializeField] Animator animator;

    public void Serch()
    {
        //敵とCubeの位置を取得
        Vector3 vec = cube.transform.position - this.transform.position;
        //Debug.Log("vec.sqrMagnitude : " + vec.sqrMagnitude);

        //一定距離以内でCubeを探す
        if (vec.sqrMagnitude < SerchArea * SerchArea)
        {
            //Debug.Log("Cubeを発見!!");
            animator.SetBool("b_Kick", true);
        }
        else
        {
            //Debug.Log("Cubeが居ない!!");
            animator.SetBool("b_Kick", false);
        }
    }
}

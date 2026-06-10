using UnityEngine;

public class リスコフのメインクラス : MonoBehaviour
{
    void Start()
    {
        //親クラスを子クラスに置き換えても壊れないことがリスコフの置換原則
        MoveBird(new スズメ());
        MoveBird(new ペンギン());
    }

    /// <summary>
    /// 親クラスの鳥を引数に取っている
    /// </summary>
    /// <param name="トリ"></param>
    public void MoveBird(鳥 トリ)
    {
        トリ.Move();
    }
}

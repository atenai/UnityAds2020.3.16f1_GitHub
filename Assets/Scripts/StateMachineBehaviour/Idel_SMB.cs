using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idel_SMB : StateMachineBehaviour
{
    //Enemy_Behaviourクラスの実体
    Enemy_Behaviour behavior;

    // Stateに入った時に一度だけ実効されます。Start関数みたいなものです。
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Enemy_Behaviourを取得
        behavior = animator.GetComponent<Enemy_Behaviour>();
        Debug.Log("Idel_SMB_OnStateEnter");
    }

    //Update関数です。
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //捜索関数を呼び出す
        behavior.Serch();
        Debug.Log("Idel_SMB_OnStateUpdate");
    }

    // stateが終了、ほかのstateに移動するとき一回だけ呼ばれます。
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //IdleStateが抜けた時に処理を書きたい場合ここに書いてください
        Debug.Log("Idel_SMB_OnStateExit");
    }

    // RootMotionに関する処理を書く関数です
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // IKに関する処理を書く関数です
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

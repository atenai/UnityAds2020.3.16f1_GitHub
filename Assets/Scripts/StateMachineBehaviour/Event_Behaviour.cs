using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Behaviour : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Start()
    {
        SetEvent();
    }

    /// <summary>
    /// 全てのベースレイヤーについているビヘイビアを取得してその中の関数を呼び出す
    /// </summary>
    void SetEvent()
    {
        var stateMachines = animator.GetBehaviours<BaseLayerAnimatorStateMachineBehaviour>();
        foreach (var stateMachine in stateMachines)
        {
            stateMachine.Test();

            //ステートから出たときのイベントを登録
            stateMachine.AddStateExitEvent(OnAnimatorStateExitEvent);
        }
    }

    void OnAnimatorStateExitEvent(EventInfo info)
    {

    }
}

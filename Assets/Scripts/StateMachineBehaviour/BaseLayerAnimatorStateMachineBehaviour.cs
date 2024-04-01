using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アニメーションコントローラーのベースレイヤーに付けるステートマシンビヘイビア
/// </summary>
public class BaseLayerAnimatorStateMachineBehaviour : StateMachineBehaviour
{
    //AnimatorStateInfoは、アニメーターコンポーネントが現在再生中のアニメーションステートに関する情報を提供します。
    //1.normalizedTime: アニメーションの正規化された再生時間（0から1の範囲）。この値を使用すると、アニメーションが再生されている特定の位置を把握できます。
    //2.length: アニメーションの再生時間（秒単位）。この値は、アニメーションクリップの長さを示します。
    //3.speed: アニメーションの再生速度。この値を変更することで、アニメーションの再生速度を調整できます。
    //4.loop: アニメーションがループするかどうかを示すブール値。trueの場合、アニメーションはループ再生されます。

    /// <summary>
    /// ステートに入ったときの処理
    /// </summary>
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("<color=red>" + animator.GetCurrentAnimatorClipInfo(0)[0].clip.name + " : アニメーション開始</color>");
    }

    /// <summary>
    /// ステートの更新時の処理
    /// </summary>
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    /// <summary>
    /// ステートから出たときの処理
    /// </summary>
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("<color=blue>" + animator.GetCurrentAnimatorClipInfo(0)[0].clip.name + " : アニメーション終了</color>");
    }
}

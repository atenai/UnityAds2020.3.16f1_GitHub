using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStateMachineBehaviour : StateMachineBehaviour
{
    //AnimatorStateInfoは、アニメーターコンポーネントが現在再生中のアニメーションステートに関する情報を提供します。
    //1.normalizedTime: アニメーションの正規化された再生時間（0から1の範囲）。この値を使用すると、アニメーションが再生されている特定の位置を把握できます。
    //2.length: アニメーションの再生時間（秒単位）。この値は、アニメーションクリップの長さを示します。
    //3.speed: アニメーションの再生速度。この値を変更することで、アニメーションの再生速度を調整できます。
    //4.loop: アニメーションがループするかどうかを示すブール値。trueの場合、アニメーションはループ再生されます。

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // ステートに入ったときの処理
        Debug.Log("Entered state: " + stateInfo.shortNameHash);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // ステートから出たときの処理
        Debug.Log("Exited state: " + stateInfo.shortNameHash);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // ステートの更新時の処理
        Debug.Log("State update: " + stateInfo.shortNameHash);
    }

    // 他のイベントハンドラやメソッドを追加することもできます
}

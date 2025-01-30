using UnityEngine;
using System.Collections;
using Fungus;

public class SkipAllDialog : MonoBehaviour
{
    // スキップ中かどうか
    bool skipping = false;
    Coroutine skipRoutine = null;

    public void OnSkipButtonClicked()
    {
        if (!skipping)
        {
            skipping = true;
            skipRoutine = StartCoroutine(SkipRoutine());
        }
        else
        {
            // 二度押しでスキップ解除
            skipping = false;
            if (skipRoutine != null)
            {
                StopCoroutine(skipRoutine);
                skipRoutine = null;
            }
        }
    }

    IEnumerator SkipRoutine()
    {
        // すべての Writer を瞬間表示モードにする
        Writer[] writers = FindObjectsOfType<Writer>();
        foreach (var w in writers)
        {
            // これだけだと外部から instantComplete を書き換えられないので
            // 下記のように Reflection を使う or Writer.csを改造して public にする
            // w.instantComplete = true; // 直接はアクセス不可
        }

        while (skipping)
        {
            // すべての Writer に対して OnNextLineEvent() を連打
            // → すると「瞬間表示 → 次の行 → 瞬間表示 → 次の行…」を超高速で繰り返す
            foreach (var w in writers)
            {
                if (w.IsWriting || w.IsWaitingForInput)
                {
                    w.OnNextLineEvent();
                }
            }

            // 毎フレーム連打
            yield return null;
        }

        // スキップ解除時、元の書き込み速度に戻したり、フラグを戻したりするならここで処理
        // ...
    }
}

using UnityEngine;
using System.Collections;
using Fungus;

public class SkipAllDialog1 : MonoBehaviour
{
    [SerializeField] Writer writer;

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
        while (skipping)
        {
            // すべての Writer に対して OnNextLineEvent() を連打
            // → すると「瞬間表示 → 次の行 → 瞬間表示 → 次の行…」を超高速で繰り返す

            if (writer.IsWriting || writer.IsWaitingForInput)
            {
                writer.OnNextLineEvent();
            }


            // 毎フレーム連打
            yield return null;
        }
    }
}

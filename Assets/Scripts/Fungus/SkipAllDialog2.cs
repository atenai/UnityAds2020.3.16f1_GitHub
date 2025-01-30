using UnityEngine;
using System.Collections;
using Fungus;
using UnityEngine.EventSystems;  // ★ これが必要

public class SkipAllDialog2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Writer writer;

    // スキップ中かどうか
    bool isSkipping = false;
    Coroutine skipRoutine = null;

    // Pointerを押したときに呼ばれる
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isSkipping)
        {
            isSkipping = true;
            skipRoutine = StartCoroutine(SkipRoutine());
        }
    }

    // Pointerを離したときに呼ばれる
    public void OnPointerUp(PointerEventData eventData)
    {
        if (isSkipping)
        {
            isSkipping = false;
            if (skipRoutine != null)
            {
                StopCoroutine(skipRoutine);
                skipRoutine = null;
            }

            // スキップ解除時に「通常の速度に戻す」
            ResetInstantComplete(false);
        }
    }

    IEnumerator SkipRoutine()
    {
        while (isSkipping)
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

    private void ResetInstantComplete(bool newValue)
    {
        writer.InstantComplete = newValue;
    }
}

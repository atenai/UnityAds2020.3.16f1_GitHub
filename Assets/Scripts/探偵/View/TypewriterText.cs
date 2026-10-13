using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace 探偵
{
    /// <summary>文章を1文字ずつ表示する。タップでComplete()を呼べば一気に全文を出せる。</summary>
    [RequireComponent(typeof(Text))]
    public class TypewriterText : MonoBehaviour
    {
        [SerializeField] float charactersPerSecond = 45f;

        Text _text;
        string _full = "";
        Coroutine _routine;

        public bool IsPlaying => _routine != null;

        /// <summary>全文が表示されたとき（スキップしたときも）に発火する。</summary>
        public event Action OnCompleted;

        Text Label => _text != null ? _text : (_text = GetComponent<Text>());

        public void Play(string full)
        {
            if (_routine != null) StopCoroutine(_routine);
            _full = full ?? "";
            _routine = StartCoroutine(TypeRoutine());
        }

        public void Complete()
        {
            if (_routine != null)
            {
                StopCoroutine(_routine);
                _routine = null;
            }
            Label.text = _full;
            OnCompleted?.Invoke();
        }

        void OnDisable()
        {
            // 非表示中はコルーチンが止まるので、途中で閉じられたら全文の状態にしておく
            if (_routine == null) return;
            _routine = null;
            Label.text = _full;
        }

        IEnumerator TypeRoutine()
        {
            float shown = 0f;
            Label.text = "";
            while ((int)shown < _full.Length)
            {
                shown += Time.unscaledDeltaTime * charactersPerSecond;
                Label.text = _full.Substring(0, Mathf.Min(_full.Length, (int)shown));
                yield return null;
            }
            _routine = null;
            Label.text = _full;
            OnCompleted?.Invoke();
        }
    }
}

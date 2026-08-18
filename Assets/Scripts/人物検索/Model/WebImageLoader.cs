using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace 人物検索
{
    /// <summary>
    /// サムネイルを取ってSpriteにする。同じURLは2度取りに行かない。
    /// まとめて投げるとWikimediaに429で弾かれるので、1件ずつ間隔を空けて取りに行く。
    /// コルーチンを回すためにMonoBehaviourを借りている。
    /// </summary>
    public sealed class WebImageLoader : IImageLoader
    {
        const string UserAgent = "UnityPersonTableSample/1.0 (Unity learning project)";
        const float RequestGap = 0.2f;
        const float RetryDelay = 1.5f;
        const int MaxRetries = 2;

        class Pending
        {
            public string Url;
            public Action<Sprite> Callback;
            public int Attempt;
        }

        readonly MonoBehaviour _runner;
        readonly Dictionary<string, Sprite> _cache = new Dictionary<string, Sprite>();
        readonly Queue<Pending> _queue = new Queue<Pending>();

        bool _pumping;

        public WebImageLoader(MonoBehaviour runner)
        {
            _runner = runner;
        }

        public void Load(string url, Action<Sprite> onLoaded)
        {
            if (string.IsNullOrEmpty(url))
            {
                onLoaded(null);
                return;
            }

            Sprite cached;
            if (_cache.TryGetValue(url, out cached))
            {
                onLoaded(cached);
                return;
            }

            _queue.Enqueue(new Pending { Url = url, Callback = onLoaded, Attempt = 0 });
            if (!_pumping) _runner.StartCoroutine(PumpRoutine());
        }

        IEnumerator PumpRoutine()
        {
            _pumping = true;
            while (_queue.Count > 0)
            {
                yield return Fetch(_queue.Dequeue());
                yield return new WaitForSeconds(RequestGap);
            }
            _pumping = false;
        }

        IEnumerator Fetch(Pending pending)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(pending.Url);
            request.SetRequestHeader("User-Agent", UserAgent);
            request.timeout = 20;

            yield return request.SendWebRequest();

            Sprite sprite = null;
            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(request);
                if (texture != null)
                {
                    sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height),
                        new Vector2(0.5f, 0.5f));
                }
            }

            // 混雑や回線の失敗はやり直す価値があるが、DataProcessingError は
            // Unityがデコードできない画像(CMYKのJPEGなど)なので、何度やっても通らない。
            bool retryable = request.result == UnityWebRequest.Result.ConnectionError
                || (request.result == UnityWebRequest.Result.ProtocolError && request.responseCode == 429);
            request.Dispose();

            if (sprite == null && retryable && pending.Attempt < MaxRetries)
            {
                pending.Attempt++;
                _queue.Enqueue(pending);
                yield return new WaitForSeconds(RetryDelay);
                yield break;
            }

            if (sprite != null) _cache[pending.Url] = sprite;
            pending.Callback(sprite);
        }
    }
}

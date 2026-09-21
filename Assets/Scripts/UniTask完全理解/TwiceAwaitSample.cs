using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;

public class TwiceAwaitSample : MonoBehaviour
{
    void Start()
    {
        var token = this.GetCancellationTokenOnDestroy();
        DoAsync(token).Forget();
    }

    async UniTaskVoid DoAsync(CancellationToken cancellationToken)
    {
        try
        {
            //HTTP GET を行い結果をキャッシュするUniTask
            var uniTask = GetAsync("https://unity.com/ja", cancellationToken);

            //1回目のawaitは問題ない
            await uniTask;
            //同じオブジェクトに対して2回以上のawaitはできない
            //(InvalidOperationExceptionが発行される)
            await uniTask;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    async UniTask<string> GetAsync(string url, CancellationToken cancellationToken)
    {
        using (var request = UnityWebRequest.Get(url))
        {
            await request.SendWebRequest().WithCancellation(cancellationToken);
            return request.downloadHandler.text;
        }
    }
}

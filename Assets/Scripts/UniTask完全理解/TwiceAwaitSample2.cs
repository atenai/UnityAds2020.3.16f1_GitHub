using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;

public class TwiceAwaitSample2 : MonoBehaviour
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

            //Preserve()を使うことで、何回でもawait可能なUniTaskに変換できる
            var reusable = uniTask.Preserve();

            await reusable;
            await reusable;
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

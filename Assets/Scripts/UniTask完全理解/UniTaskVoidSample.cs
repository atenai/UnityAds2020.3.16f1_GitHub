using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class UniTaskVoidSample : MonoBehaviour
{
    void Start()
    {
        //UniTaskVoidは実行完了を待機できない
        //そのため実行後そのまま放置したいときに利用できる
        DoAsync().Forget();
    }

    async UniTaskVoid DoAsync()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(10));
        Destroy(gameObject);
    }
}

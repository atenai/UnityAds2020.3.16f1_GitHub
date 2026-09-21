using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class UniTaskVoidSample2 : MonoBehaviour
{
    async UniTaskVoid Start()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(10));
        Destroy(gameObject);
    }
}

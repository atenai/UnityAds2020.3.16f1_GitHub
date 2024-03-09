using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;

public class AddressableTest : MonoBehaviour
{
    [SerializeField] Image image;

    void Start()
    {
        //必ず型が一緒かつアドレッサブルアセットに登録した名前が一致しないとエラーになる
        Addressables.LoadAssetAsync<Sprite>("Title").Completed += sprite =>
        {
            image.sprite = sprite.Result;
        };
    }
}

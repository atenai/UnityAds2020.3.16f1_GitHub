using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class AssetReferenceTest : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] AssetReference logo;

    void Start()
    {
        //必ず型が一緒かつアドレッサブルアセットに登録した名前が一致しないとエラーになる
        Addressables.LoadAssetAsync<Sprite>(logo).Completed += sprite =>
        {
            image.sprite = sprite.Result;
        };
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class AssetReferenceTest1 : MonoBehaviour
{
    [SerializeField] AssetReference cube;

    void Start()
    {
        //必ず型が一緒かつアドレッサブルアセットに登録した名前が一致しないとエラーになる
        Addressables.LoadAssetAsync<GameObject>(cube).Completed += gameObject =>
        {
            Instantiate(gameObject.Result);
        };
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ShotManager : MonoBehaviour
{
    //弾のプレファブ
    [SerializeField] private GameObject bullet_prefab;

    //オブジェクトプール本体
    ObjectPool<GameObject> pool;


    ///プライベートで公式のまま↓

    void Start()
    {
        pool = new ObjectPool<GameObject>
        (
            OnCreatePoolObject,
            OnTakeFromPool,
            OnReturnedToPool,
            OnDestroyPoolObject,
            false,
            2,
            5//貯める数
        );
    }

    //ObjectPoolコンストラクタ1つ目の引数の関数
    //プールに空きがないときに新たに生成する処理
    //objectPool.Get()が呼ばれる
    GameObject OnCreatePoolObject()
    {
        GameObject o = Instantiate(bullet_prefab);
        return o;
    }

    //ObjectPoolコンストラクタ2つ目の引数の関数
    //プールに空きがあったときの処理
    //objectPool.Get()が呼ばれる
    void OnTakeFromPool(GameObject target)
    {
        target.SetActive(true);
    }

    //ObjectPoolコンストラクタ3つ目の引数の関数
    //プールに返却するときの処理
    void OnReturnedToPool(GameObject target)
    {
        target.SetActive(false);
    }

    //ObjectPoolコンストラクタ4つ目の引数の関数
    //MAXサイズより多くなったときに自動で破棄する
    void OnDestroyPoolObject(GameObject target)
    {
        Destroy(target);
    }

    ///プライベートで公式のまま↑

    //プレイヤーから呼び出して画面に弾を発生させる
    //プレイヤーから呼び出され、ObjectPoolから弾を引き出してプレイヤーにわたしてあげるメソッド
    public GameObject GetShot()
    {
        //ObjectPoolからオブジェクトをもらうにはObjectPoolのGet()を使います。
        //第二引数に指定したOnTakeFromPool が呼ばれます。
        //※空きがなかったときは第一引数のOnCreatePoolObject が先に呼ばれます
        GameObject o = pool.Get();
        o.GetComponent<ShotBase>().shotManager = this;
        return o;
    }

    //弾から呼び出して画面から弾を消滅させる
    //弾から呼び出して、非表示にするメソッド
    public void DelShot(GameObject o)
    {
        //逆に非表示にするにはRelease()を使います。
        //第三引数に指定したOnReturnedToPool が呼ばれます。
        pool.Release(o);
    }
}

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


    ///↓プライベートで公式のまま↓///
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
            5//プールに貯められる最大数
        );
    }

    //ObjectPoolコンストラクタ1つ目の引数の関数
    //プールに空きがないときに新たに生成する処理
    //objectPool.Get()が呼ばれる
    GameObject OnCreatePoolObject()
    {
        GameObject gameObject = Instantiate(bullet_prefab);
        return gameObject;
    }

    //ObjectPoolコンストラクタ2つ目の引数の関数
    //プールに空きがあったときの処理
    //objectPool.Get()が呼ばれる
    void OnTakeFromPool(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    //ObjectPoolコンストラクタ3つ目の引数の関数
    //プールに返却するときの処理
    void OnReturnedToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    //ObjectPoolコンストラクタ4つ目の引数の関数
    //MAXサイズより多くなったときに自動で破棄する
    void OnDestroyPoolObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
    ///↑プライベートで公式のまま↑///

    //プレイヤーから呼び出して画面に弾を発生させる
    //プレイヤーから呼び出され、ObjectPoolから弾を引き出してプレイヤーにわたしてあげるメソッド
    public GameObject GetShot()
    {
        //ObjectPoolからオブジェクトをもらうにはObjectPoolのGet()を使います。
        //第二引数に指定したOnTakeFromPool が呼ばれます。
        //※空きがなかったときは第一引数のOnCreatePoolObject が先に呼ばれます
        GameObject gameObject = pool.Get();
        gameObject.GetComponent<ShotBase>().shotManager = this;//弾を生成して、弾にプール情報のコンポーネントを入れる（↓の関数DelShotを使うために必要）
        return gameObject;
    }

    //弾から呼び出して画面から弾を消滅させる
    //弾から呼び出して、非表示にするメソッド
    public void DelShot(GameObject gameObject)
    {
        //逆に非表示にするにはRelease()を使います。
        //第三引数に指定したOnReturnedToPool が呼ばれます。
        pool.Release(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : ShotBase
{
    [SerializeField] float speed = 1.0f;

    void Update()
    {
        if (5 <= transform.position.y)
        {
            //y軸が5以上のならったらこのゲームオブジェクトを返却する
            shotManager.DelShot(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        //このゲームオブジェクトを移動させる
        this.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
    }
}

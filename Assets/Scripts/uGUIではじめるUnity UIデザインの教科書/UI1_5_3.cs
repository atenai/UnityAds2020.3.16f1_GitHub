using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI1_5_3 : MonoBehaviour
{
    private float rotationSpeed;//回転速度を設定するフィールド

    void Start()
    {
        rotationSpeed = 10.0f;//回転速度を初期化
    }

    void Update()
    {
        //回転させる角度を算出する
        float yAngle = rotationSpeed * Time.deltaTime;
        //ゲームオブジェクトをY軸を基準に回転させる
        this.transform.Rotate(0.0f, yAngle, 0.0f);
    }
}

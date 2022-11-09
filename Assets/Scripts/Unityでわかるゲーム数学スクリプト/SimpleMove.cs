using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    //private Vector3 v3Position = new Vector3(0.0f, 0.5f, 0.0f);
    //private Vector3 v3Velocity = new Vector3(0.2f, 0.0f, 0.0f);
    //private Vector3 v3Velocity = new Vector3(0.1f, 0.0f, 0.0f);
    //private float fVelocity = 0.1f;
    //private float fAngle = Mathf.PI / 6.0f;

    private Vector3 v3BasePosition = new Vector3(0.0f, 6.0f, 0.0f);
    private Vector3 v3BaseVelocity = new Vector3(0.1f, 0.0f, 0.0f);
    private Vector3 v3Position;
    private Vector3 v3Velocity;
    private float fGravity = -0.003f;

    void Start()
    {
        //StartSimpleMove1_1or2();
        //StartSimpleMove1_1a();
        //StartSimpleMove2_1();
        //StartSimpleMove3_1();
        //StartSimpleMove3_2();
        StartSimpleMove4_1();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        //FixedUpdateSimpleMove1_1();
        //FixedUpdateSimpleMove1_2();
        //FixedUpdateSimpleMove1_1a();
        //FixedUpdateSimpleMove2_1();
        //FixedUpdateSimpleMove2_2();
        //FixedUpdateSimpleMove2_3();
        //FixedUpdateSimpleMove3_1();
        //FixedUpdateSimpleMove3_2();
        FixedUpdateSimpleMove4_1();
    }

    //void StartSimpleMove1_1or2()
    //{
    //    transform.position = v3Position;
    //}

    //void FixedUpdateSimpleMove1_1()
    //{
    //    v3Position = v3Position + v3Velocity;

    //    transform.position = v3Position;
    //}

    //void FixedUpdateSimpleMove1_2()
    //{
    //    v3Position = v3Position + v3Velocity;

    //    if (5.0f < v3Position.x)
    //    {
    //        v3Position.x = 5.0f;
    //        v3Velocity.x = -v3Velocity.x;
    //    }
    //    if (v3Position.x < -5.0f)
    //    {
    //        v3Position.x = -5.0f;
    //        v3Velocity.x = -v3Velocity.x;
    //    }

    //    transform.position = v3Position;
    //}

    //void StartSimpleMove1_1a()
    //{
    //    transform.position = new Vector3(0.0f, 0.5f, 0.0f);
    //}

    //void FixedUpdateSimpleMove1_1a()
    //{
    //    transform.Translate(0.2f, 0.0f, 0.0f);
    //}

    //void StartSimpleMove2_1()
    //{
    //    transform.position = v3Position;
    //}

    //void FixedUpdateSimpleMove2_1()
    //{
    //    Vector3 v3Velocity = new Vector3(0.0f, 0.0f, 0.0f);
    //    v3Velocity.x = Input.GetAxis("Horizontal") * fVelocity;

    //    v3Position += v3Velocity;//位置に速度を足す

    //    transform.position = v3Position;

    //    if (transform.position.x > 5.0f)
    //    {
    //        transform.position = new Vector3(5.0f, transform.position.y, transform.position.z);
    //    }
    //    if (transform.position.x < -5.0f)
    //    {
    //        transform.position = new Vector3(-5.0f, transform.position.y, transform.position.z);
    //    }
    //}

    //void FixedUpdateSimpleMove2_2()
    //{
    //    Vector3 v3Velocity = new Vector3(0.0f, 0.0f, 0.0f);
    //    v3Velocity.x = Input.GetAxis("Horizontal") * fVelocity;
    //    v3Velocity.z = Input.GetAxis("Vertical") * fVelocity;

    //    v3Position += v3Velocity;//位置に速度を足す

    //    if (v3Position.x > 5.0f)
    //    {
    //        v3Position.x = 5.0f;
    //    }
    //    if (v3Position.x < -5.0f)
    //    {
    //        v3Position.x = -5.0f;
    //    }
    //    if (v3Position.z > 5.0f)
    //    {
    //        v3Position.z = 5.0f;
    //    }
    //    if (v3Position.z < -5.0f)
    //    {
    //        v3Position.z = -5.0f;
    //    }

    //    transform.position = v3Position;
    //}

    //void FixedUpdateSimpleMove2_3()
    //{
    //    Vector3 v3Velocity = new Vector3(0.0f, 0.0f, 0.0f);
    //    v3Velocity.x = Input.GetAxis("Horizontal") * fVelocity;
    //    v3Velocity.z = Input.GetAxis("Vertical") * fVelocity;

    //    float fInputVel = Mathf.Sqrt(v3Velocity.x * v3Velocity.x + v3Velocity.z * v3Velocity.z);//速さ

    //    if (fInputVel > fVelocity)
    //    {
    //        v3Velocity = v3Velocity / fInputVel * fVelocity;//速さ調整
    //    }

    //    v3Position += v3Velocity;//位置に速度を足す

    //    if (v3Position.x > 5.0f)
    //    {
    //        v3Position.x = 5.0f;
    //    }
    //    if (v3Position.x < -5.0f)
    //    {
    //        v3Position.x = -5.0f;
    //    }
    //    if (v3Position.z > 5.0f)
    //    {
    //        v3Position.z = 5.0f;
    //    }
    //    if (v3Position.z < -5.0f)
    //    {
    //        v3Position.z = -5.0f;
    //    }

    //    transform.position = v3Position;
    //}

    //void StartSimpleMove3_1()
    //{
    //    transform.position = v3Position;
    //    v3Velocity.x = fVelocity * Mathf.Cos(fAngle);//初速の設定
    //    v3Velocity.y = fVelocity * Mathf.Sin(fAngle);
    //}

    //void FixedUpdateSimpleMove3_1()
    //{
    //    v3Position += v3Velocity;//位置に速度を足す

    //    if ((v3Position.x > 5.0f) || (v3Position.x < -5.0f) || (v3Position.z > 5.0f) || (v3Position.z < -5.0f))//地面から出ているか
    //    {
    //        v3Position = new Vector3(0.0f, 0.5f, 0.0f);//位置を初期化する
    //    }

    //    transform.position = v3Position;
    //}

    //void StartSimpleMove3_2()
    //{
    //    transform.position = v3Position;
    //}

    //void FixedUpdateSimpleMove3_2()
    //{
    //    v3Position += v3Velocity;//位置に速度を足す

    //    if ((v3Position.x > 5.0f) || (v3Position.x < -5.0f) || (v3Position.z > 5.0f) || (v3Position.z < -5.0f))//地面から出ているか
    //    {
    //        v3Position = new Vector3(0.0f, 0.5f, 0.0f);//位置を初期化する
    //        fAngle += 2.0f * Mathf.PI / 10.0f;//方向回転
    //        if (fAngle > (2.0f * Mathf.PI))//Mathf.PIはπ //このifと中身は、角度が1周分より大きくなったら、角度を1周分だけ減らすという処理をしている
    //        {
    //            fAngle -= 2.0f * Mathf.PI;
    //        }
    //        v3Velocity.x = fVelocity * Mathf.Cos(fAngle);
    //        v3Velocity.z = fVelocity * Mathf.Sin(fAngle);
    //    }

    //    transform.position = v3Position;
    //}

    void StartSimpleMove4_1()
    {
        v3Position = v3BasePosition;//位置を初期化
        v3Velocity = v3BaseVelocity;//速度を初期化
        transform.position = v3Position;
    }

    void FixedUpdateSimpleMove4_1()
    {
        v3Position += v3Velocity;//位置に速度を足す
        v3Velocity.y += fGravity;//速度に加速度を足す

        if (v3Position.y < 0.0f)//地面に落ちたか
        {
            v3Position = v3BasePosition;//位置を初期化
            v3Velocity = v3BaseVelocity;//速度を初期化
        }

        transform.position = v3Position;
    }
}

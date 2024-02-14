using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://kan-kikuchi.hatenablog.com/entry/Mathf

public class SimpleMove : MonoBehaviour
{
    //private Vector3 v3Position = new Vector3(0.0f, 0.5f, 0.0f);
    //private Vector3 v3Velocity = new Vector3(0.2f, 0.0f, 0.0f);
    //private Vector3 v3Velocity = new Vector3(0.1f, 0.0f, 0.0f);
    //private float fVelocity = 0.1f;
    //private float fAngle = Mathf.PI / 6.0f;

    //private Vector3 v3BasePosition = new Vector3(0.0f, 6.0f, 0.0f);
    //private Vector3 v3BaseVelocity = new Vector3(0.1f, 0.0f, 0.0f);
    //private Vector3 v3BasePosition = new Vector3(-5.0f, 0.5f, 0.0f);
    private Vector3 v3BasePosition = new Vector3(0.0f, 0.5f, 0.0f);
    private Vector3 v3BaseVelocity = new Vector3(0.1f, 0.2f, 0.0f);
    //private Vector3 v3Position;
    //private Vector3 v3Velocity;
    private float fGravity = -0.003f;
    private float t = 0.0f;//時刻


    private const float fRot_r = 5.0f;//回転半径
    private const float fAngle_Vel = 2.0f * Mathf.PI / 50.0f;
    private Vector3 v3Position = new Vector3(fRot_r, 0.5f, 0.0f);//位置
    private Vector3 v3Velocity = new Vector3(0.0f, 0.0f, fRot_r * fAngle_Vel);
    private float fAngle = 0.0f;//角度

    void Start()
    {
        //StartSimpleMove1_1or2();
        //StartSimpleMove1_1a();
        //StartSimpleMove2_1();
        //StartSimpleMove3_1();
        //StartSimpleMove3_2();
        //StartSimpleMove4_1();
        //StartSimpleMove4_2();
        //StartSimpleMove4_3();
        //StartSimpleMove5_1();
        //StartSimpleMove5_1a();
        //StartSimpleMove5_2();
        //StartSimpleMove6_1();
        StartSimpleMove6_2();
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
        //FixedUpdateSimpleMove4_1();
        //FixedUpdateSimpleMove4_2();
        //FixedUpdateSimpleMove4_3();
        //FixedUpdateSimpleMove5_1();
        //FixedUpdateSimpleMove6_1();
        FixedUpdateSimpleMove6_2();
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

    //    v3Position += v3Velocity;

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

    //    v3Position += v3Velocity;

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

    //    float fInputVel = Mathf.Sqrt(v3Velocity.x * v3Velocity.x + v3Velocity.z * v3Velocity.z);

    //    if (fInputVel > fVelocity)
    //    {
    //        v3Velocity = v3Velocity / fInputVel * fVelocity;
    //    }

    //    v3Position += v3Velocity;

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
    //    v3Velocity.x = fVelocity * Mathf.Cos(fAngle);
    //    v3Velocity.y = fVelocity * Mathf.Sin(fAngle);
    //}

    //void FixedUpdateSimpleMove3_1()
    //{
    //    v3Position += v3Velocity;

    //    if ((v3Position.x > 5.0f) || (v3Position.x < -5.0f) || (v3Position.z > 5.0f) || (v3Position.z < -5.0f))
    //    {
    //        v3Position = new Vector3(0.0f, 0.5f, 0.0f);
    //    }

    //    transform.position = v3Position;
    //}

    //void StartSimpleMove3_2()
    //{
    //    transform.position = v3Position;
    //}

    //void FixedUpdateSimpleMove3_2()
    //{
    //    v3Position += v3Velocity;

    //    if ((v3Position.x > 5.0f) || (v3Position.x < -5.0f) || (v3Position.z > 5.0f) || (v3Position.z < -5.0f))
    //    {
    //        v3Position = new Vector3(0.0f, 0.5f, 0.0f);
    //        fAngle += 2.0f * Mathf.PI / 10.0f;
    //        if (fAngle > (2.0f * Mathf.PI))
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
        v3Position = v3BasePosition;
        v3Velocity = v3BaseVelocity;
        transform.position = v3Position;
    }

    void FixedUpdateSimpleMove4_1()
    {
        v3Position += v3Velocity;
        v3Velocity.y += fGravity;

        if (v3Position.y < 0.0f)
        {
            v3Position = v3BasePosition;
            v3Velocity = v3BaseVelocity;
        }

        transform.position = v3Position;
    }

    void StartSimpleMove4_2()
    {
        v3Position = v3BasePosition;
        v3Velocity = v3BaseVelocity;
        transform.position = v3Position;
    }

    void FixedUpdateSimpleMove4_2()
    {
        v3Position += v3Velocity;
        v3Velocity.y += fGravity;

        if (v3Position.y < 0.0f)
        {
            v3Position = v3BasePosition;
            v3Velocity = v3BaseVelocity;
        }

        transform.position = v3Position;
    }

    void StartSimpleMove4_3()
    {
        v3Position = v3BasePosition;//位置を初期化
        t = 0.0f;//時刻を初期化
        transform.position = v3Position;
    }

    void FixedUpdateSimpleMove4_3()
    {
        v3Position.x = v3BaseVelocity.x * t + v3BasePosition.x;//位置に加速度を足す
        v3Position.y = 0.5f * fGravity * t * t + v3BaseVelocity.y * t + v3BasePosition.y;//速度に加速度を足す
        t++;

        if (v3Position.y < 0.0f)//地面に落ちたか
        {
            t = 0.0f;//時刻を初期化
        }

        transform.position = v3Position;
    }

    void StartSimpleMove5_1()
    {
        v3Position = v3BasePosition;//位置を初期化
        v3Velocity = new Vector3(Random.Range(-0.2f, 0.2f), 0.2f, Random.Range(-0.2f, 0.2f));//速度を初期化
        transform.position = v3Position;
    }

    void FixedUpdateSimpleMove5_1()
    {
        v3Position += v3Velocity;//位置に速度を足す
        v3Velocity.y += fGravity;//速度に加速度を足す

        if (v3Position.y < 0.0f)
        {
            Destroy(gameObject);//地面に落ちたか
        }

        transform.position = v3Position;
    }

    void StartSimpleMove5_1a()
    {
        float fRadius, fAngle;
        v3Position = v3BasePosition;//位置を初期化
        fRadius = Random.Range(0.0f, 0.2f);
        fAngle = Random.Range(0.0f, 2.0f * Mathf.PI);
        v3Velocity = new Vector3(fRadius * Mathf.Cos(fAngle), 0.2f, fRadius * Mathf.Sin(fAngle));//速度を初期化
        transform.position = v3Position;
    }

    void StartSimpleMove5_2()
    {
        float fRand_r, fRand_Angle;
        v3Position = v3BasePosition;//位置を初期化
        fRand_r = Mathf.Sqrt(-2.0f * Mathf.Log(Random.Range(0.0f, 1.0f)));// √-2ln(a)
        fRand_Angle = Random.Range(0.0f, 2.0f * Mathf.PI);
        v3Velocity = new Vector3(0.2f * fRand_r * Mathf.Cos(fRand_Angle), 0.2f, 0.2f * fRand_r * Mathf.Sin(fRand_Angle));//速度を初期化
        transform.position = v3Position;
    }

    void StartSimpleMove6_1()
    {
        transform.position = v3Position;
    }

    void FixedUpdateSimpleMove6_1()
    {
        v3Position = new Vector3(fRot_r * Mathf.Cos(fAngle), 0.5f, fRot_r * Mathf.Sin(fAngle));//回転
        fAngle += 2.0f * Mathf.PI / 50.0f;//角度を進める
        transform.position = v3Position;
    }

    void StartSimpleMove6_2()
    {
        transform.position = v3Position;
    }

    void FixedUpdateSimpleMove6_2()
    {
        v3Position += v3Velocity;//位置に速度を
        v3Velocity += -new Vector3(v3Position.x, 0.0f, v3Position.z) * fAngle_Vel * fAngle_Vel;//速度に加速度を
        transform.position = v3Position;
    }
}

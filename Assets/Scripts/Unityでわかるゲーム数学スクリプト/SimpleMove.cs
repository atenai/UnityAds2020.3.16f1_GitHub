using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    private Vector3 v3Position = new Vector3(0.0f, 0.5f, 0.0f);
    private Vector3 v3Velocity = new Vector3(0.2f, 0.0f, 0.0f);
    private float fVelocity = 0.1f;

    void Start()
    {
        //StartSimpleMove1_1or2();
        //StartSimpleMove1_1a();
        StartSimpleMove2_1();
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
        FixedUpdateSimpleMove2_2();
    }

    void StartSimpleMove1_1or2()
    {
        transform.position = v3Position;
    }

    void FixedUpdateSimpleMove1_1()
    {
        v3Position = v3Position + v3Velocity;

        transform.position = v3Position;
    }

    void FixedUpdateSimpleMove1_2()
    {
        v3Position = v3Position + v3Velocity;

        if (5.0f < v3Position.x)
        {
            v3Position.x = 5.0f;
            v3Velocity.x = -v3Velocity.x;
        }
        if (v3Position.x < -5.0f)
        {
            v3Position.x = -5.0f;
            v3Velocity.x = -v3Velocity.x;
        }

        transform.position = v3Position;
    }

    void StartSimpleMove1_1a()
    {
        transform.position = new Vector3(0.0f, 0.5f, 0.0f);
    }

    void FixedUpdateSimpleMove1_1a()
    {
        transform.Translate(0.2f, 0.0f, 0.0f);
    }

    void StartSimpleMove2_1()
    {
        transform.position = v3Position;
    }

    void FixedUpdateSimpleMove2_1()
    {
        Vector3 v3Velocity = new Vector3(0.0f, 0.0f, 0.0f);
        v3Velocity.x = Input.GetAxis("Horizontal") * fVelocity;

        v3Position += v3Velocity;//位置に速度を足す

        transform.position = v3Position;

        if (transform.position.x > 5.0f)
        {
            transform.position = new Vector3(5.0f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -5.0f)
        {
            transform.position = new Vector3(-5.0f, transform.position.y, transform.position.z);
        }
    }

    void FixedUpdateSimpleMove2_2()
    {
        Vector3 v3Velocity = new Vector3(0.0f, 0.0f, 0.0f);
        v3Velocity.x = Input.GetAxis("Horizontal") * fVelocity;
        v3Velocity.z = Input.GetAxis("Vertical") * fVelocity;

        v3Position += v3Velocity;//位置に速度を足す

        if (v3Position.x > 5.0f)
        {
            v3Position.x = 5.0f;
        }
        if (v3Position.x < -5.0f)
        {
            v3Position.x = -5.0f;
        }
        if (v3Position.z > 5.0f)
        {
            v3Position.z = 5.0f;
        }
        if (v3Position.z < -5.0f)
        {
            v3Position.z = -5.0f;
        }

        transform.position = v3Position;
    }
}

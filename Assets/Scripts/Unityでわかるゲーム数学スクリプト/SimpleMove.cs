using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    private Vector3 v3Position = new Vector3(0.0f, 0.5f, 0.0f);
    private Vector3 v3Velocity = new Vector3(0.2f, 0.0f, 0.0f);

    void Start()
    {
        //StartSimpleMove1_1or2();
        StartSimpleMove1_1a();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        //FixedUpdateSimpleMove1_1();
        //FixedUpdateSimpleMove1_2();
        FixedUpdateSimpleMove1_1a();
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
}

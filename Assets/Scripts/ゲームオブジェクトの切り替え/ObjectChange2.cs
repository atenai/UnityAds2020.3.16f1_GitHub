using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChange2 : MonoBehaviour
{
    [SerializeField]
    public GameObject[] cubeArray;
    private int count;
    public GameObject cubeObj;

    void Start()
    {
        var parent = this.transform;

        count = 0;
        cubeObj = GameObject.Instantiate(cubeArray[count], Vector3.zero, Quaternion.identity, parent) as GameObject;
    }

    public void CubeSet()
    {
        var parent = this.transform;

        Destroy(cubeObj);

        count++;

        cubeObj = GameObject.Instantiate(cubeArray[count], Vector3.zero, Quaternion.identity, parent) as GameObject;

        if (count == 2)
        {
            count = -1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 参考サイト
/// https://backbone-studio.com/blog-unitycloth/
/// </summary>
public class GetVtx : MonoBehaviour
{
    void Start()
    {
        Mesh myMesh = GetComponent<MeshFilter>().mesh;
        for (int i = 0; i < myMesh.vertices.Length; i++)
        {
            Debug.Log(myMesh.vertices[i]);
        }
    }
}
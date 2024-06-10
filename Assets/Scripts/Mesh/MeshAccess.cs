using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 参考サイト
/// https://qiita.com/Torihaka1/items/910d1365dddc031aecaf
/// </summary>
public class MeshAccess : MonoBehaviour
{
    void Start()
    {
        // 頂点数を数える
        int vtx_num = 0;
        foreach (Transform child in this.gameObject.transform)
        {
            SkinnedMeshRenderer skin = child.GetComponent<SkinnedMeshRenderer>();
            vtx_num += skin.sharedMesh.vertices.Length;
        }
        Vector3[] vtx_posi_array = new Vector3[vtx_num];

        // 頂点座標を取得
        int count = 0;
        foreach (Transform child in this.gameObject.transform)
        {
            SkinnedMeshRenderer skin = child.GetComponent<SkinnedMeshRenderer>();
            Mesh child_mesh = skin.sharedMesh;
            for (int i = 0; i < child_mesh.vertices.Length; i++)
            {
                float x = child_mesh.vertices[i].x;
                float y = child_mesh.vertices[i].y;
                float z = child_mesh.vertices[i].z;
                vtx_posi_array[count] = new Vector3(x, y, z);
                count++;
            }
        }

        for (int i = 0; i < vtx_posi_array.Length; ++i)
        {
            UnityEngine.Debug.Log("<color=red>vtx_posi_array[i].x : " + vtx_posi_array[i].x + "</color>");
            UnityEngine.Debug.Log("<color=blue>vtx_posi_array[i].y : " + vtx_posi_array[i].y + "</color>");
            UnityEngine.Debug.Log("<color=green>vtx_posi_array[i].z : " + vtx_posi_array[i].z + "</color>");
        }
    }
}
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary> 
public class Example15 : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        //ギズモの色を変更
        Gizmos.color = new Color32(145, 244, 139, 210);
        Gizmos.DrawWireCube(this.transform.position, this.transform.lossyScale);
    }
}
#endif
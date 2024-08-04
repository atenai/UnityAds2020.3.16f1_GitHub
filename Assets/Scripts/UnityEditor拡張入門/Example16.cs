#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 
/// </summary> 
public class Example16 : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        var trace = new System.Diagnostics.StackTrace();
        var frame = trace.GetFrame(1);

        if (frame.GetMethod().Name == "INTERNAL_CALL_RenderGameViewCameras")
        {
            Gizmos.color = Color.red;

            Gizmos.DrawCube(Vector3.zero, Vector3.one);
        }
    }
}
#endif
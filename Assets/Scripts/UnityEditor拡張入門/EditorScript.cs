#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorScript
{
    //[DrawGizmo(GizmoType.NonSelected | GizmoType.Active)]
    [DrawGizmo(GizmoType.InSelectionHierarchy)]
    static void DrawExampleGizmos(Example15 example15, GizmoType gizmoType)
    {
        var transform = example15.transform;
        Gizmos.color = new Color32(145, 244, 139, 210);

        //GizmoType.Activeの時は赤色にする
        if ((gizmoType & GizmoType.Active) == GizmoType.Active)
        {
            Gizmos.color = Color.red;
        }

        Gizmos.DrawWireCube(transform.position, transform.lossyScale);
    }
}
#endif
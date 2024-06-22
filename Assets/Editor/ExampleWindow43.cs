using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class ExampleWindow43 : EditorWindow
{
    int groupID = 0;

    //ウィンドウ作成
    [MenuItem("Kashiwabara/Example43")]
    static void Open()
    {
        GetWindow<ExampleWindow43>();
    }

    void OnEnable()
    {
        groupID = Undo.GetCurrentGroup();
    }

    void OnDisable()
    {
        Undo.CollapseUndoOperations(groupID);
    }

    void OnGUI()
    {
        if (GUILayout.Button("Cube 作成"))
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            Undo.RegisterCreatedObjectUndo(cube, "Create Cube");
        }

        if (GUILayout.Button("Plane 作成"))
        {
            var plane = GameObject.CreatePrimitive(PrimitiveType.Plane);

            Undo.RegisterCreatedObjectUndo(plane, "Create Plane");
        }

        if (GUILayout.Button("Cylinder 作成"))
        {
            var cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

            Undo.RegisterCreatedObjectUndo(cylinder, "Create Cylinder");
        }
    }
}

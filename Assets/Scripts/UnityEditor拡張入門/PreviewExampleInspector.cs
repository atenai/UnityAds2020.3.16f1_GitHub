using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PreviewExample))]
public class PreviewExampleInspector : Editor
{
    public override bool HasPreviewGUI()
    {
        return true;
    }
}

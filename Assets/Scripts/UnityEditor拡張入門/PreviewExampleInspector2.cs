using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

[CustomEditor(typeof(PreviewExample2))]
public class PreviewExampleInspector2 : Editor
{
    PreviewRenderUtility previewRenderUtility;
    GameObject previewObject;

    void OnEnable()
    {
        var component = (Component)target;
        previewObject = Instantiate(component.gameObject);
        previewObject.hideFlags = HideFlags.HideAndDontSave;
        previewObject.SetActive(false);

        var flags = BindingFlags.Static | BindingFlags.NonPublic;
        var propInfo = typeof(Camera).GetProperty("PreviewCullingLayer", flags);
        int previewLayer = (int)propInfo.GetValue(null, new object[0]);

        previewRenderUtility = new PreviewRenderUtility(true);
        //previewLayerのみを表示する
        previewRenderUtility.camera.cullingMask = 1 << previewLayer;
    }
}

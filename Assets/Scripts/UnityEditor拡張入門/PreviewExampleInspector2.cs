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

        previewObject.layer = previewLayer;
        foreach (Transform transform in previewObject.transform)
        {
            transform.gameObject.layer = previewLayer;
        }

        Bounds bounds = new Bounds(component.transform.position, Vector3.zero);
        //階層下のRendererコンポーネントをすべて取得
        foreach (var renderer in previewObject.GetComponentsInChildren<Renderer>())
        {
            bounds.Encapsulate(renderer.bounds);
        }

        //一番大きいBoundsの中心位置
        var centerPosition = bounds.center;
    }

    public override void OnInteractivePreviewGUI(Rect r, GUIStyle background)
    {
        previewRenderUtility.BeginPreview(r, background);

        previewObject.SetActive(true);

        previewRenderUtility.camera.Render();

        previewObject.SetActive(false);

        previewRenderUtility.EndAndDrawPreview(r);
    }
}

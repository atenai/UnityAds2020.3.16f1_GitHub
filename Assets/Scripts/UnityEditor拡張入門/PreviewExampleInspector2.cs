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
    }

    // void OnDisabale()
    // {
    //     previewRenderUtility.Cleanup();
    //     previewRenderUtility = null;
    //     previewObject = null;
    // }

    // public override bool HasPreviewGUI()
    // {
    //     return true;
    // }

    // public override void OnPreviewGUI(Rect r, GUIStyle background)
    // {
    //     previewRenderUtility.BeginPreview(r, background);

    //     var previewCamera = previewRenderUtility.m_Camera;

    //     previewCamera.transform.position = previewObject.transform.position + new Vector3(0, 2.5f, -5);

    //     previewCamera.transform.LookAt(previewObject.transform);

    //     previewCamera.Render();

    //     previewRenderUtility.EndAndDrawPreview(r);

    //     //描画タイミングが少ないことによって
    //     //カクつきがきになる時はRepaintを呼び出す（高負荷）
    //     //Repaint();
    // }
}

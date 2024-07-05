#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PreviewExample1))]
public class PreviewExampleInspector1 : Editor
{
    PreviewRenderUtility previewRenderUtility;
    GameObject previewObject;

    // void OnEnable()
    // {
    //     //trueにすることでシーン内のゲームオブジェクトを描画できるようになる
    //     previewRenderUtility = new PreviewRenderUtility(true);

    //     //FieldOfViewを30にするとちょうどいい見た目になる
    //     previewRenderUtility.m_CameraFieldOfView = 30f;

    //     //必要に応じてnearClipPlaneとfarClipPlaneを設定
    //     previewRenderUtility.m_Camera.nearClipPlane = 0.3f;
    //     previewRenderUtility.m_Camera.farClipPlane = 1000;

    //     //コンポーネント経由でゲームオブジェクトを取得
    //     var component = (Component)target;
    //     previewObject = component.gameObject;
    // }

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
#endif
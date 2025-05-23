#if UNITY_EDITOR
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
    Vector3 centerPosition;

    void OnEnable()
    {
        var flags = BindingFlags.Static | BindingFlags.NonPublic;
        var propInfo = typeof(Camera).GetProperty("PreviewCullingLayer", flags);
        int previewLayer = (int)propInfo.GetValue(null, new object[0]);

        previewRenderUtility = new PreviewRenderUtility(true);
        previewRenderUtility.cameraFieldOfView = 30f;
        //previewLayerのみを表示する
        previewRenderUtility.camera.cullingMask = 1 << previewLayer;

        var component = (Component)target;
        previewObject = Instantiate(component.gameObject);
        previewObject.hideFlags = HideFlags.HideAndDontSave;


        previewObject.layer = previewLayer;
        foreach (Transform transform in previewObject.transform)
        {
            transform.gameObject.layer = previewLayer;
        }

        Bounds bounds = new Bounds(component.transform.position, Vector3.zero);
        //階層下のRendererコンポーネントをすべて取得
        foreach (var renderer in previewObject.GetComponentsInChildren<Renderer>())
        {
            //一番大きいBoundsを取得する
            bounds.Encapsulate(renderer.bounds);
        }

        //プレビューオブジェクトの中心位置として変数に代入
        centerPosition = bounds.center;
        previewObject.SetActive(false);

        //オブジェクト角度の初期値
        //このくらいの値が斜めから見下ろす形になる
        RotatePreviewObject(new Vector2(-120, 20));
    }

    public override GUIContent GetPreviewTitle()
    {
        return new GUIContent(target.name + " Preview");
    }

    void OnDisable()
    {
        DestroyImmediate(previewObject);
        previewRenderUtility.Cleanup();
        previewRenderUtility = null;
    }

    public override bool HasPreviewGUI()
    {
        return true;
    }

    public override void OnInteractivePreviewGUI(Rect r, GUIStyle background)
    {
        previewRenderUtility.BeginPreview(r, background);

        var drag = Vector2.zero;
        //ドラッグ時のマウスの移動量を取得
        if (Event.current.type == EventType.MouseDrag)
        {
            drag = Event.current.delta;
        }

        //中心位置から一定の距離離れたところにカメラを設置
        previewRenderUtility.camera.transform.position = centerPosition + Vector3.forward * -5;

        //マウスの移動量をオブジェクトの角度に適用
        RotatePreviewObject(drag);

        previewObject.SetActive(true);

        previewRenderUtility.camera.Render();

        previewObject.SetActive(false);

        previewRenderUtility.EndAndDrawPreview(r);

        //ドラッグした時は再描画を行う
        //これを行わないとカクカクした動きになってしまう
        if (drag != Vector2.zero)
        {
            Repaint();
        }
    }

    private void RotatePreviewObject(Vector2 drag)
    {
        previewObject.transform.RotateAround(centerPosition, Vector3.up, -drag.x);

        previewObject.transform.RotateAround(centerPosition, Vector3.right, -drag.y);
    }
}
#endif
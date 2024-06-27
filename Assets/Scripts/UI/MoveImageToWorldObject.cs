using UnityEngine;

public class MoveImageToWorldObject : MonoBehaviour
{
    [SerializeField] RectTransform canvasImage; // Canvas上のImageのRectTransform
    [SerializeField] Transform worldObject; // ワールド座標のオブジェクト
    [SerializeField] Canvas canvas; // Canvas
    [SerializeField] Camera mainCamera; // メインカメラ

    void Update()
    {
        // ワールド座標をスクリーン座標に変換
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(worldObject.position);

        // スクリーン座標をCanvasのRectTransform座標に変換
        Vector2 canvasPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPosition, null, out canvasPosition);

        // Imageの位置を更新
        canvasImage.localPosition = canvasPosition;
    }
}

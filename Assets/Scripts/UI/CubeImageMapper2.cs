using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CubeImageMapper2 : MonoBehaviour
{
    [SerializeField] RectTransform imagePrefab; // Canvas上のImageのプレハブ
    [SerializeField] Canvas canvas; // Canvas
    [SerializeField] Vector2 offset; // Imageのオフセット
    [SerializeField] Camera mainCamera; // メインカメラ

    public List<Transform> cubes = new List<Transform>(); // キューブのリスト
    public List<RectTransform> images = new List<RectTransform>(); // Imageのリスト


    void Update()
    {
        // 現在のキューブを更新
        UpdateCubes();

        // キューブに対応するImageの数を調整
        AdjustImages();

        // キューブの位置にImageを配置
        UpdateImagePositions();
    }

    void UpdateCubes()
    {
        // シーン上のすべてのキューブを取得（エネミーID3は例外にして非表示にする）
        cubes.Clear();
        foreach (var cube in GameObject.FindGameObjectsWithTag("Cube"))
        {
            cubes.Add(cube.transform);
        }
    }

    void AdjustImages()
    {
        // キューブの数に合わせてImageの数を調整
        while (images.Count < cubes.Count)
        {
            RectTransform newImage = Instantiate(imagePrefab, canvas.transform);
            images.Add(newImage);
        }

        while (images.Count > cubes.Count)
        {
            RectTransform toRemove = images[images.Count - 1];
            images.RemoveAt(images.Count - 1);
            Destroy(toRemove.gameObject);
        }
    }

    void UpdateImagePositions()
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            // キューブのワールド座標をスクリーン座標に変換
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(cubes[i].position);

            // スクリーン座標をCanvasのRectTransform座標に変換
            Vector2 canvasPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPosition, null, out canvasPosition);

            // オフセットを適用
            canvasPosition += offset;

            // Imageの位置を更新
            images[i].localPosition = canvasPosition;
        }
    }
}

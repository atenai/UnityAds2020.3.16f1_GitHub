using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CubeImageMapper1 : MonoBehaviour
{
    [SerializeField] RectTransform imagePrefab; // Canvas上のImageのプレハブ
    [SerializeField] Canvas canvas; // Canvas
    [SerializeField] Camera mainCamera; // メインカメラ

    public List<Transform> cubeList = new List<Transform>(); // キューブのリスト
    public List<RectTransform> imageList = new List<RectTransform>(); // Imageのリスト

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
        // シーン上のすべてのキューブを取得
        cubeList.Clear();
        foreach (var cube in GameObject.FindGameObjectsWithTag("Cube"))
        {
            cubeList.Add(cube.transform);
        }
    }

    void AdjustImages()
    {
        // キューブの数に合わせてImageの数を調整
        while (imageList.Count < cubeList.Count)
        {
            RectTransform newImage = Instantiate(imagePrefab, canvas.transform);
            imageList.Add(newImage);
        }

        while (cubeList.Count < imageList.Count)
        {
            RectTransform toRemove = imageList[imageList.Count - 1];
            imageList.RemoveAt(imageList.Count - 1);
            Destroy(toRemove.gameObject);
        }
    }

    void UpdateImagePositions()
    {
        for (int i = 0; i < cubeList.Count; i++)
        {
            // キューブのワールド座標をスクリーン座標に変換
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(cubeList[i].position);

            // スクリーン座標をCanvasのRectTransform座標に変換
            Vector2 canvasPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPosition, null, out canvasPosition);

            // Imageの位置を更新
            imageList[i].localPosition = canvasPosition;
        }
    }
}

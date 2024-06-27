using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CubeImageMapper : MonoBehaviour
{
    [SerializeField] RectTransform imagePrefab; // Canvas上のImageのプレハブ
    [SerializeField] Canvas canvas; // Canvas
    [SerializeField] Camera mainCamera; // メインカメラ

    //値が何が入っているかわかりやすくするためにpublicにしている
    public List<Transform> cubes = new List<Transform>(); // キューブのリスト
    //値が何が入っているかわかりやすくするためにpublicにしている
    public List<RectTransform> images = new List<RectTransform>(); // Imageのリスト

    void Start()
    {
        // シーン上のすべてのキューブの座標を取得してリストに登録
        foreach (var cube in GameObject.FindGameObjectsWithTag("Cube"))
        {
            cubes.Add(cube.transform);
        }

        // キューブの数だけImageを生成してリストに登録
        foreach (var cube in cubes)
        {
            RectTransform newImage = Instantiate(imagePrefab, canvas.transform);
            images.Add(newImage);
        }
    }

    void Update()
    {
        //キューブの数だけ回す
        for (int i = 0; i < cubes.Count; i++)
        {
            // キューブのワールド座標をスクリーン座標に変換
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(cubes[i].position);

            // スクリーン座標をCanvasのRectTransform座標に変換
            Vector2 canvasPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPosition, null, out canvasPosition);

            // Imageの位置を更新
            images[i].localPosition = canvasPosition;
        }
    }
}

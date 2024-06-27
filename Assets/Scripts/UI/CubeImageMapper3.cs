using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CubeImageMapper3 : MonoBehaviour
{
    [SerializeField] GameObject prefab; // Canvas上のImageのプレハブ
    [SerializeField] Canvas canvas; // Canvas
    [SerializeField] Vector2 offset; // Imageのオフセット
    [SerializeField] Camera mainCamera; // メインカメラ

    public List<GameObject> cubeList = new List<GameObject>(); // キューブのリスト
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
            cubeList.Add(cube);
        }
    }

    void AdjustImages()
    {
        // キューブの数に合わせてImageの数を調整
        while (imageList.Count < cubeList.Count)
        {
            GameObject newImageObject = Instantiate(prefab, canvas.transform);
            RectTransform newImage = newImageObject.GetComponent<RectTransform>();
            imageList.Add(newImage);
        }

        while (imageList.Count > cubeList.Count)
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
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(cubeList[i].transform.position);

            // スクリーン座標をCanvasのRectTransform座標に変換
            Vector2 canvasPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPosition, null, out canvasPosition);

            // オフセットを適用
            canvasPosition = canvasPosition + offset;

            // Imageの位置を更新
            imageList[i].localPosition = canvasPosition;
            imageList[i].GetComponent<Slider>().value = cubeList[i].GetComponent<CubeParameters>().HP;

            //（エネミーID3は例外にして非表示にする）
            if (cubeList[i].GetComponent<CubeParameters>().EnemyID == 3)
            {
                imageList[i].gameObject.SetActive(false);
            }
        }
    }
}

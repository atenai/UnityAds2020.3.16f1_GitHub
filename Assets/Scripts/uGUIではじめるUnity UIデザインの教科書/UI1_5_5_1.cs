using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI1_5_5_1 : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;//立方体のプレハブ

    void Start()
    {

    }

    void Update()
    {

    }

    public void Generate()
    {
        //立方体のプレハブをインスタンス化
        GameObject obj = Instantiate(cubePrefab) as GameObject;
        //インスタンスを「CubeGenerator」オブジェクトの子要素にする
        obj.transform.SetParent(this.transform);
        //インスタンスのスケールにプレハブを合わせる
        obj.transform.localScale = cubePrefab.transform.localScale;
        //インスタンスの位置を「CubeGenerator」オブジェクトに合わせる
        obj.transform.position = this.transform.position;
        //落下の度に変化するようにランダムな回転角度にする
        obj.transform.rotation = Random.rotation;
    }
}

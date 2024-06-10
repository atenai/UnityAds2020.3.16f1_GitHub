using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 参考サイト
/// https://backbone-studio.com/blog-unitycloth/
/// </summary>
public class GetVtx : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    void Start()
    {
        //Mesh Filter コンポーネントはメッシュへの参照を保存します。
        //Mesh Filter コンポーネントは同じゲームオブジェクト上の Mesh Renderer コンポーネントと連動し、Mesh Renderer は Mesh Filter が参照するメッシュを描画します。
        //https://docs.unity3d.com/ja/2022.2/Manual/class-MeshFilter.html
        Mesh myMesh = GetComponent<MeshFilter>().mesh;
        for (int i = 0; i < myMesh.vertices.Length; i++)
        {
            Debug.Log(myMesh.vertices[i]);
            // プレファブをインスタンス化し、親オブジェクトの子として設定
            //GameObject gameObject = Instantiate(prefab, myMesh.vertices[i] + this.transform.position, Quaternion.identity);
            GameObject gameObject = Instantiate(prefab, myMesh.vertices[i], Quaternion.identity);
            gameObject.transform.SetParent(this.transform, false);//第二引数をfalseにするとローカル座標を破棄した子オブジェクトになる（その為、通常はtrueにするが今回の場合の例外）
        }
    }
}
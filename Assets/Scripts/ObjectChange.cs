using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChange : MonoBehaviour
{
    [SerializeField]
    public GameObject[] cubeArray;
    private int count;
    public GameObject cubeObj;

    void Start()
    {
        count = 0;
        //cubeArray[0番目]のゲームオブジェクトをインスタンスして
        //as演算子でGameObjectの配列型からGameObject型に変更してcubeObjに格納
        cubeObj = GameObject.Instantiate(cubeArray[count]) as GameObject;
    }

    public void CubeSet()
    {
        //CubeSet()関数が呼ばれたら中身を実行する
        //cubeObjを破棄
        Destroy(cubeObj);
        //番数目を+1する
        count++;
        //cubeArray[0番目]のゲームオブジェクトをインスタンスして
        //as演算子でGameObjectの配列型からGameObject型に変更してcubeObjに格納
        cubeObj = GameObject.Instantiate(cubeArray[count]) as GameObject;
        //最大数(2)になったらカウントを-1に変更する
        //そうすれば次の+1で0番目に戻る事ができる為
        if (count == 2)
        {
            count = -1;
        }
    }
}
